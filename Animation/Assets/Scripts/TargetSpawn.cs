using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawn : MonoBehaviour
{
    public GameObject[] targetPrefab;
    int number = 10;
    private float spawnRangeX;
    private float spawnPosZ;
    private float spawnRangeXx;
    private float spawnPosZz;
    // private float startDelay = 2;
    // private float spawnInterval = 800;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < number; i++)
        {
            // InvokeRepeating("SpawnRandomTarget", startDelay, spawnInterval);
            SpawnRandomTarget();

        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomTarget()
    {

        spawnRangeX = Random.Range(-20, -500);

        spawnPosZz = Random.Range(-20, -500);

        spawnRangeXx = Random.Range(20, 500);

        spawnPosZ = Random.Range(20, 500);

        int targetIndex = Random.Range(0, targetPrefab.Length);
        Vector3 randomSpawn = new Vector3(Random.Range(spawnRangeX, spawnRangeXx), 1, Random.Range(spawnPosZ, spawnPosZz));

        Instantiate(targetPrefab[targetIndex], randomSpawn, Quaternion.identity);

    }
}
