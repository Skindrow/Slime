using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float spawnBoundX;
    [SerializeField] private float spawnBoundY;
    [SerializeField] private GameObject[] spawnedGO;
    [SerializeField] private RectTransform canvasRectTransform;
    [SerializeField] private Transform canvasTransform;

    private void Awake()
    {

    }
    private void Start()
    {
        spawnBoundX = canvasRectTransform.rect.width - canvasRectTransform.rect.width / 10;
        spawnBoundY = canvasRectTransform.rect.height - canvasRectTransform.rect.height / 10;
        StartCoroutine(SpawnBursts());
    }




    private IEnumerator SpawnBursts()
    {
        while (true)
        {
            int rnd = Random.Range(0, spawnedGO.Length);

            GameObject burstGO = Instantiate(spawnedGO[rnd].gameObject, canvasTransform);


            float rndX = Random.Range(-spawnBoundX / 2, spawnBoundX / 2);
            float rndY = Random.Range(-spawnBoundY / 2, spawnBoundY / 2);

            burstGO.transform.localPosition = new Vector3(rndX, rndY, 0);

            yield return new WaitForSeconds(timeToSpawn);
        }
    }

}
