using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    public static SpawnerScript SharedInstance;

    public GameObject enemy;
    public List<GameObject> enemies;
    public int amountOfEnemies;

    public float enemySpawnStartTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        SharedInstance = this;
        for(int i= 0; i<amountOfEnemies; i++)
        {
            GameObject obj = Instantiate(enemy);
            obj.SetActive(false);
            enemies.Add(obj);
        }

        // Ajastin: Käynnistä(Kutsuttavan funktion nimi, viive sekunteina)
        InvokeRepeating("ActivateEnemy", enemySpawnStartTime, 2f);
    }

    public GameObject GetPooledEnemy()
    {
        for (int i = 0; i < amountOfEnemies; i++)
        {
            if(!enemies[i].activeInHierarchy)
            {
                return enemies[i];
            }
        }
        return null;
    }

    public void ActivateEnemy()
    {
        // Note that enemy name exists as global and local variable and these are seperate variables. 
        GameObject enemy = GetPooledEnemy();
        if(enemy != null)
        {
            enemy.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
