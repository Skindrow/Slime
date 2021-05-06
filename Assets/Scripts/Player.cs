﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject heart;
    [SerializeField] private int hpCount;
    [SerializeField] private string loseSceneName;


    private List<GameObject> hpArr = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < hpCount; i++)
        {
            GameObject hpGO = Instantiate(heart, new Vector3(-10 + i, -4.2f, 0), Quaternion.identity);
            hpArr.Add(hpGO);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "DamageObject")
        {
            PlayerDamaged();
        }
    }

    public void PlayerDamaged()
    {
        hpCount--;
        Destroy(hpArr[hpCount].gameObject);

        if (hpCount == 0)
        {
            SceneLoader.SceneLoad(loseSceneName);

            TimeCounter.time = 0;
        }



        DestroyAllDO();

    }
    private void DestroyAllDO()
    {
        GameObject[] allDamageObjects = GameObject.FindGameObjectsWithTag("DamageObject");
        foreach (GameObject damageGO in allDamageObjects)
        {
            Destroy(damageGO);
        }
    }
}
