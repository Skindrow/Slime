using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstsSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float spawnBoundX;
    [SerializeField] private float spawnBoundY;
    [SerializeField] private Bursts[] bursts;
    [SerializeField] private float timeBeforeDestroy;

    private void Start()
    {
        StartCoroutine(SpawnBursts());
    }



    private IEnumerator SpawnBursts()
    {
        while (true)
        {
            int rnd = Random.Range(0, bursts.Length);

            float rndX = Random.Range(-spawnBoundX, spawnBoundX);
            float rndY = Random.Range(-spawnBoundY, spawnBoundY);

            GameObject burstGO = Instantiate(bursts[rnd].gameObject, new Vector2(rndX, rndY), Quaternion.identity);

            Destroy(burstGO.gameObject, timeBeforeDestroy);

            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    
}
