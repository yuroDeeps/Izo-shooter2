using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{

    public GameObject zombie;
    public int MaxZombieCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnZombie();
    }

    private void SpawnZombie ()
    {
        var currentZombieCount = GameObject.FindGameObjectsWithTag("Enemy");

        if (currentZombieCount.Count() < MaxZombieCount)
        {
            var position = GetRandomPosition();

            if (Physics.CheckSphere(position, 2))
            {
                Instantiate(zombie, position, Quaternion.identity);
            }
        }
    }

    private Vector3 GetRandomPosition()
    {
        var x = Random.Range(-10f, 10f);
        var z = Random.Range(-10f, 10f);
        var position = new Vector3(x, 0f, z);

        return position;
    }
}
