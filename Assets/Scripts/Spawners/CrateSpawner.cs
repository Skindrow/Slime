using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private float force;
    [SerializeField] private float rangeToAttentionZone;
    [SerializeField] private GameObject attentionZone;
    [SerializeField] private GameObject crate;
    [SerializeField] private float zoneOfSpawn;
    [SerializeField] private float yCoord;
    [SerializeField] private float[] crateScale = new float[2];

    private Rigidbody2D rb;

    private void Start()
    {
        StartCoroutine(SpawnCrates());
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private IEnumerator SpawnCrates()
    {
        while (true)
        {
            float x = Random.Range(-zoneOfSpawn, zoneOfSpawn);
            Vector3 rndPosAttentionZone = new Vector3(x, yCoord, 0);
            Vector3 rndPosCrate = new Vector3(x, yCoord + rangeToAttentionZone, 0);
            Destroy(Instantiate(attentionZone, rndPosAttentionZone, Quaternion.identity), timeToSpawn);


            GameObject crateGO = Instantiate(crate, rndPosCrate, Quaternion.identity);
            float scale = Random.Range(crateScale[0], crateScale[1]);
            crateGO.transform.localScale = new Vector3(scale, scale, 1);

            //rb.AddForce(new Vector2(0,-force));


            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
