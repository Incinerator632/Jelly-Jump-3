using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] objectPrefabs;

    private float spawnLimitXLeft = -55.5f;
    private float spawnLimitXRight = 55.5f;
    private float spawnPosY = 1650; //22

    private float startDelay = 0.5f;
    private float spawnInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomObject", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void SpawnRandomObject()
    {
        // Generate random utensil index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        int objectIndex = Random.Range(0, objectPrefabs.Length);
        // instantiate utensil at random spawn location
        Instantiate(objectPrefabs[objectIndex], spawnPos, objectPrefabs[objectIndex].transform.rotation);
    }
}
