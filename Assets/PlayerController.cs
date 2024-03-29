using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.AI;
using Unity.VisualScripting.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    float hp = 10;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    public float playerSpeed = 2;
    Vector2 movementVector;
    Transform bulletSpawn;
    public GameObject hpBar;
    Scrollbar hpScrollBar;

    NavMeshAgent agent;

    public static bool startTime = false;

    // Start is called before the first frame update
    void Start()
    {
        movementVector = Vector2.zero;
        bulletSpawn = transform.Find("BulletSpawn");
        hpScrollBar = hpBar.GetComponent<Scrollbar>();
        agent = GetComponent<NavMeshAgent>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTime)
        {
            Time.timeScale = 1;
        }
        //obr�t wok� osi Y o ilo�� stopni r�wn� wartosci osi X kontrolera
        transform.Rotate(Vector3.up * movementVector.x);
        //przesuni�cie do przodu (transform.forward) o wychylenie osi Y kontrolera w czasie jednej klatki
        //transform.Translate(Vector3.forward * movementVector.y * Time.deltaTime * playerSpeed);
        if(movementVector.y > 0 )
        {
            agent.isStopped = false;
            agent.destination = transform.position + transform.forward;
        }
        if(movementVector.y == 0 )
        {
            agent.isStopped = true;
        }

    }
    
    void OnMove(InputValue inputValue) 
    {
        movementVector = inputValue.Get<Vector2>();

        //Debug.Log(movementVector.ToString());
    }

    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.transform.parent = null;
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward*bulletSpeed, ForceMode.VelocityChange);
        Destroy(bullet, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
   
            hp--;
            if(hp <= 0) Die();
            hpScrollBar.size = hp / 10;
            Vector3 pushVector = collision.gameObject.transform.position - transform.position;
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(pushVector.normalized*5, ForceMode.Impulse);
        } else if (collision.gameObject.CompareTag("Heal"))
        {
            hp = 10;
            hpScrollBar.size = hp / 10;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            hp--;
            if (hp <= 0) Die();
            hpScrollBar.size = hp / 10;
            Vector3 pushVector = collision.gameObject.transform.position - transform.position;
            //collision.gameObject.GetComponent<Rigidbody>().AddForce(pushVector.normalized*5, ForceMode.Impulse);
        }
        else if (collision.gameObject.CompareTag("Heal"))
        {
            hp = 10;
            hpScrollBar.size = hp / 10;
            Destroy(collision.gameObject);
        }
    }

    void Die()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        
        //Time.timeScale = 0;
    }

    public void Heal()
    {
        hp = 10;
    }
}
