using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = GameObject.Find("Spawner").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "EnemyKiller")
        {
            transform.position = spawnPoint.position;
            gameObject.SetActive(false);
        }
    }

}
