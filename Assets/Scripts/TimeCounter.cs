using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    [SerializeField] private Text timeText;

    public static int time = 0;
    void Start()
    {
        StartCoroutine(TimeCount());
    }

    private IEnumerator TimeCount()
    {
        while (true)
        {
            timeText.text = time.ToString();
            time++;
            yield return new WaitForSeconds(1);
        }
    }
}
