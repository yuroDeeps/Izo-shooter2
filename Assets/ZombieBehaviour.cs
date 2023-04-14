using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieBehaviour : MonoBehaviour
{
    int hp = 10;

    GameObject player;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(hp> 0)
        {
            transform.LookAt(player.transform.position);
            //Vector3 playerDirection = transform.position - player.transform.position;

            //transform.Translate(Vector3.forward * Time.deltaTime);
            agent.destination= player.transform.position;
        }
        
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Bullet"))
    //    {
    //        Destroy(collision.gameObject);
    //        hp--;
    //        if(hp <= 0)
    //        {
    //            transform.Translate(Vector3.up);
    //            transform.Rotate(Vector3.right * -90);
    //            transform.GetComponent<BoxCollider>().enabled = false;
    //            transform.gameObject.tag = "Untagged";
    //            Destroy(transform.gameObject, 10);
    //        }
    //    }
    //}

    public void ReciveDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
        
    
}
