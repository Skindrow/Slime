using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float timeToReact;
    [SerializeField] private float maxTime;
    [SerializeField] private float minTime;
    [SerializeField] private GameObject spikes;
    [SerializeField] private GameObject attentionZone;



    private void Start()
    {
        StartCoroutine(SpawnSpikes());
    }

    private IEnumerator SpawnSpikes()
    {
        while (true)
        {
            GameObject attentionZoneGO = Instantiate(attentionZone, new Vector2(0, -3), Quaternion.identity);
            yield return new WaitForSeconds(timeToReact);
            Destroy(attentionZoneGO.gameObject);

            GameObject spikesGO = Instantiate(spikes, new Vector2(0, -3), Quaternion.identity);
            float rnd = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(rnd);
            Destroy(spikesGO.gameObject);

            yield return new WaitForSeconds(timeToSpawn);


        }


    }
}
