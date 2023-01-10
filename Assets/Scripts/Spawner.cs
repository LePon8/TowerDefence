using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject enemyToSpawn;
    [SerializeField] int spawnRate;
    [SerializeField] Transform leftSpawnLimit;
    [SerializeField] Transform rightSpawnLimit;

    float leftLimit, rightLimit;

    float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        leftLimit = leftSpawnLimit.position.x;
        rightLimit = rightSpawnLimit.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= spawnRate)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(leftLimit, rightLimit), 0, transform.position.z);
            Instantiate(enemyToSpawn, spawnPosition, Quaternion.identity);

            spawnTimer = 0;
        }
    }
}
