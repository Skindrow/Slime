using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float spawnBoundX;
    [SerializeField] private float spawnBoundY;
    [SerializeField] private GameObject[] spawnedGO;

    private void Start()
    {
        StartCoroutine(SpawnBursts());
    }



    private IEnumerator SpawnBursts()
    {
        while (true)
        {
            int rnd = Random.Range(0, spawnedGO.Length);

            float rndX = Random.Range(-spawnBoundX, spawnBoundX);
            float rndY = Random.Range(-spawnBoundY, spawnBoundY);

            GameObject burstGO = Instantiate(spawnedGO[rnd].gameObject, new Vector2(rndX, rndY), Quaternion.identity);

            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    
}
