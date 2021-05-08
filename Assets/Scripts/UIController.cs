using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject losePanel;
    [SerializeField] private Text reachedScoreText;
    [SerializeField] private Button restartButton;
    [SerializeField] private string restartSceneName;

    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
    }



    public void Lose()
    {
        Time.timeScale = 0f;
        ScoreCounter sc = GameObject.FindObjectOfType<ScoreCounter>();
        reachedScoreText.text = "Score \n" + sc.score.ToString();
        losePanel.SetActive(true);
    }

    private void Restart()
    {
        Time.timeScale = 1f;
        SceneLoader.SceneLoad(restartSceneName);
    }
}
