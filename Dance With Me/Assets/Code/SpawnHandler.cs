using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{
    [Header("Enemy")]
    public GameObject[] enemy;

    [Header("Spawns")]
    public GameObject[] spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!FixedThings.paused && !FixedThings.prompting)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int i = Random.Range(0, enemy.Length), j = Random.Range(0, spawn.Length);
        bool flipped = (j == 1) ? true : false;

        if (Time.frameCount % (500 / GetState.speed) == 0)
        {
            GetState.speed += (int)(5f * Time.deltaTime);
            GameObject enemySpawned = Instantiate(enemy[i], spawn[j].transform.position, enemy[i].transform.rotation);
            enemySpawned.SetActive(true);
            enemySpawned.GetComponent<SpriteRenderer>().flipX = !flipped;
        }
    }
}
