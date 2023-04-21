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
        bool seesPlayer = false;
        bool hearsPlayer = false;
        RaycastHit hit;
        Vector3 playerVector = player.transform.position - transform.position;
        Debug.DrawRay(transform.position, playerVector, Color.yellow);
        if(Physics.Raycast(transform.position, playerVector, out hit))
        {
            Debug.Log("Widzê: " + hit.transform.name);
        }

        if (hit.collider.gameObject.CompareTag("Player"))
        {
            seesPlayer= true;
        } 

        //s³uch
        Collider[] nearby = Physics.OverlapSphere(transform.position, 5f);
        foreach(Collider collider in nearby)
        {
            if (collider.transform.CompareTag("Player"))
            {
                hearsPlayer= true;
            }
        }

        if(seesPlayer || hearsPlayer)
        {
            
          agent.destination = player.transform.position;
          agent.isStopped = false;
            
        } else
        {
            agent.isStopped = true;
        }
        
    }
 

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
