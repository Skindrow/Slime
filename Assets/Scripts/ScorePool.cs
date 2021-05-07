using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePool : MonoBehaviour
{
    private float score;
    private ScoreCounter sc;
    private float localScaleTreshold = 0.2f;
    private float timeToDestroy = 5;


    private void Start()
    {
        score = 10;
        sc = GameObject.FindObjectOfType<ScoreCounter>().GetComponent<ScoreCounter>();
        Destroy(gameObject, timeToDestroy);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            StartCoroutine(Drink());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator Drink()
    {
        Player player = GameObject.FindObjectOfType<Player>();
        while (transform.localScale.x > localScaleTreshold)
        {
            Vector3 scaleChange = new Vector3(-Player.drinkSpeedStatic, -Player.drinkSpeedStatic, 0);
            transform.localScale += scaleChange;
            sc.AddPoint(1);
            player.IncreaceSize(0.01f);
            yield return new WaitForSeconds(0.1f);
        }

        
        Destroy(gameObject);
    }
}
