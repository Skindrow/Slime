using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingContinueBurst : Bursts
{
    private GameObject player;
    [SerializeField] private float timeBetweenShoots;

    private void Start()
    {
        StartCoroutine(HomigMultShoot(numsOfShots));
    }
    private IEnumerator HomigMultShoot(int nOfShoots)
    {

        yield return new WaitForSeconds(timeToReact);


        for (int i = 0; i < numsOfShots; i++)
        {
            player = GameObject.FindGameObjectWithTag("Player");



            float x = player.gameObject.transform.position.x - transform.position.x;
            float y = player.gameObject.transform.position.y - transform.position.y;
            float rotZ = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 90;
            Quaternion newRotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
            transform.rotation = newRotation;

            GameObject shootGO = Instantiate(shot, transform.position, Quaternion.identity);

            shootGO.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((target.position.x - transform.position.x) * force,
                (target.position.y - transform.position.y) * force));
            yield return new WaitForSeconds(timeBetweenShoots);
        }

    }

}
