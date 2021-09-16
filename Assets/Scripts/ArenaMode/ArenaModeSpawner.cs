using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ArenaModeSpawner : MonoBehaviour
{
    public float ratio;
    public GameObject[] enemys;
    public GameObject[] spawnPoints;
    private int maxIndex;
    

    void Start()
    {
        maxIndex = 0;
        StartCoroutine(spawnear());
    }

    // Update is called once per frame

    IEnumerator spawnear()
    {
        while (true)
        {
            SpawnearEnemigo(Random.Range(0, maxIndex));
            yield return new WaitForSeconds(ratio);
        }
        
    }

    void SpawnearEnemigo(int enemyIndex)
    {
        GameObject temp;
        temp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemys[enemyIndex], temp.transform.position, temp.transform.rotation);
    }
}
