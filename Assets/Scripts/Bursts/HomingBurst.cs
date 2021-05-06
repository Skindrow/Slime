using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBurst : Bursts
{

    [SerializeField] private float coneOfAffection;
    private GameObject player;



    private void Start()
    {
        StartCoroutine(HomigMultShoot(numsOfShots));
    }
    private IEnumerator HomigMultShoot(int nOfShoots)
    {
        yield return new WaitForSeconds(timeToReact);

        player = GameObject.FindGameObjectWithTag("Player");

        shoots = new GameObject[nOfShoots];


        float x = player.gameObject.transform.position.x - transform.position.x;
        float y = player.gameObject.transform.position.y - transform.position.y;
        float rotZ = Mathf.Atan2(y, x) * Mathf.Rad2Deg + 90;

        float rotStep = coneOfAffection / (nOfShoots - 1);

        rotZ -= coneOfAffection / 2;

        Quaternion newRotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
        transform.rotation = newRotation;


        for (int i = 0; i < nOfShoots; i++)
        {
            shoots[i] = Instantiate(shot, transform.position, Quaternion.identity);

            shoots[i].gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((target.position.x - transform.position.x) * force,
                (target.position.y - transform.position.y) * force));
            rotZ += rotStep;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotZ));
        }


    }
}
