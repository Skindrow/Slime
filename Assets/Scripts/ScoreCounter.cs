using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    public int score = 0;
    void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
    }

    public void AddPoint(int inc)
    {
        score += inc;
        scoreText.text = score.ToString();
    }
}
