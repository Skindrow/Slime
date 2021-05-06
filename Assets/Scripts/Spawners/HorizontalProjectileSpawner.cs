using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalProjectileSpawner : MonoBehaviour
{
    [SerializeField] private float timeToSpawn;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject attentionZone;
    [SerializeField] private float xCoord;
    [SerializeField] private float zoneOfShooting;
    [SerializeField] private float shootSpeedf;

    public static float shootSpeed;

    private void Start()
    {
        shootSpeed = shootSpeedf;
        StartCoroutine(StartShooting());
    }

    private IEnumerator StartShooting()
    {
        while (true)
        {
            float side;


            if (Random.Range(0, 2) == 1)
                side = 1;
            else
                side = -1;



            float y = Random.Range(-zoneOfShooting, zoneOfShooting);
            Vector3 rndPosAttentionZone = new Vector3(side * xCoord, y, 0);
            Vector3 rndPosProjectile = new Vector3(side * xCoord, y, 0);
            Destroy(Instantiate(attentionZone, rndPosAttentionZone, Quaternion.identity), timeToSpawn);

            GameObject projectileGO = Instantiate(projectile, rndPosProjectile, Quaternion.identity);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
