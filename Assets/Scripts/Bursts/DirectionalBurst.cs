using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalBurst : Bursts
{
    private void Start()
    {
        StartCoroutine(DirShoot(numsOfShots));
    }


    private IEnumerator DirShoot(int nOfShoots)
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
            currentAngle += angleStep;
        }
        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));



    }
}
