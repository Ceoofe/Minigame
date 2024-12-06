using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] items;

    private float startDelay = 2;
    private float spawnInterval = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnItems", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnItems()
    {
        int itemIndex = Random.Range(0, items.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-9, 245), 2, Random.Range(-9, 225));
        Instantiate(items[itemIndex], spawnPos, items[itemIndex].transform.rotation);
    }
}
