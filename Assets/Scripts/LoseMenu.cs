using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private string playScene;


    private void Awake()
    {
        restartButton.onClick.AddListener(Restart);
    }

    private void Restart()
    {
        SceneLoader.SceneLoad(playScene);
    }
}
