using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyUpper : MonoBehaviour
{
    [SerializeField] private GameObject[] spawners;
    [SerializeField] private int[] spawnersTime;

    private void Start()
    {
        StartCoroutine(DifficultyChanger());
    }

    private IEnumerator DifficultyChanger()
    {
        for (int i = 0; i < spawners.Length; i++)
        {
            yield return new WaitForSeconds(spawnersTime[i]);
            spawners[i].SetActive(true);
        }
    }
}
