using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelController : MonoBehaviour

{
    
    private int maxZombies = 9;
    private int maxHeal = 1;
    public GameObject ZombiePrefab;
    public GameObject HealPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
       var zombies = GameObject.FindGameObjectsWithTag("Enemy");
        var heals = GameObject.FindGameObjectsWithTag("Heal");
        if (zombies.Count() < maxZombies)
        {
            SpawnZombie();
        }
        if (heals.Count() < maxHeal)
        {
            SpawnHeal();
        }
       
    }
    void SpawnZombie()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * Random.Range(10, 20);
        spawnPosition.y = 1;
        if (Physics.CheckSphere(spawnPosition, 0.9f))
        {
            spawnPosition = Random.insideUnitSphere * Random.Range(10, 20);
            spawnPosition.y = 0;
        }
        GameObject newZombie = Instantiate(ZombiePrefab, spawnPosition, Quaternion.identity);
        
    }

    void SpawnHeal()
    {
        Vector3 spawnPosition = Random.insideUnitSphere * Random.Range(10, 20);
        spawnPosition.y = 1;
        if (Physics.CheckSphere(spawnPosition, 0.9f))
        {
            spawnPosition = Random.insideUnitSphere * Random.Range(10, 20);
            spawnPosition.y = 0;
        }
        GameObject newHeal = Instantiate(HealPrefab, spawnPosition, Quaternion.identity);
    }

    public void startGame()
    {
        Time.timeScale = 1.0f;
        PlayerController.startTime = true;
        ZombieBehaviour.startTime = true;
        BulletController.startTime = true;
        var mainMenu = GameObject.FindGameObjectWithTag("MainMenu");
        mainMenu.SetActive(false);
    }
}
