using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBurst : Bursts
{

    [SerializeField] protected float timeBeforeNextShot;
    private void Start()
    {
        StartCoroutine(MultShotCircle(numsOfShots));
    }
    private IEnumerator MultShotCircle(int nOfShoots)
    {
        yield return new WaitForSeconds(timeToReact);
        float circleAngle = 360;
        float angleStep = circleAngle / nOfShoots;
        float currentAngle = 0;
        shoots = new GameObject[nOfShoots];
        for (int i = 0; i < nOfShoots; i++)
        {
            gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, currentAngle));

            shoots[i] = Instantiate(shot, transform.position, Quaternion.identity);
            shoots[i].gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2((target.position.x - transform.position.x) * force,
                (target.position.y - transform.position.y) * force));

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));

            currentAngle += angleStep;
            yield return new WaitForSeconds(timeBeforeNextShot);
        }
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));


        Destroy(gameObject);


    }
}
