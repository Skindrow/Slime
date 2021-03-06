using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePool : MonoBehaviour
{
    private ScoreCounter sc;
    private float localScaleTreshold = 0.2f;
    private float timeToDestroy = 5;

    private Player player;
    private IEnumerator drink;
    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        sc = GameObject.FindObjectOfType<ScoreCounter>().GetComponent<ScoreCounter>();
        StartCoroutine(DestroyPool());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            player.IsDrinking = true;
            StartCoroutine(drink = Drink());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            player.IsDrinking = false;
            StopCoroutine(drink);
        }
    }

    private IEnumerator Drink()
    {
        while (transform.localScale.x > localScaleTreshold)
        {
            sc.AddPoint(1);
            player.IncreaceSize(0.01f);
            Vector3 scaleChange = new Vector3(-Player.drinkSpeedStatic, -Player.drinkSpeedStatic, 0);
            transform.localScale += scaleChange;


            yield return new WaitForSeconds(0.1f);
        }
        player.IsDrinking = false;
        Destroy(gameObject);
    }

    private IEnumerator DestroyPool()
    {
        yield return new WaitForSeconds(timeToDestroy);
        player.IsDrinking = false;
        Destroy(gameObject);
    }
    private void LateUpdate()
    {
        if (transform.localScale.x < localScaleTreshold)
        {

            player.IsDrinking = false;
            Destroy(gameObject);
        }
    }


}
