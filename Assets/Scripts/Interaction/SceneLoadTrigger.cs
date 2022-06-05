using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Loads a new scene, while also clearing level-specific inventory!*/

public class SceneLoadTrigger : MonoBehaviour
{
    private int completedLevels = 1;
    [SerializeField] string loadSceneName;
    private int AddScore = 100;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == NewPlayer.Instance.gameObject)
        {
            AddScore += PlayerPrefs.GetInt("CurrentScore", 0);
            PlayerPrefs.SetInt("CurrentScore", AddScore);
            PlayerPrefs.SetInt("CompletedLevels", ++completedLevels);
            GameManager.Instance.hud.loadSceneName = loadSceneName;
            GameManager.Instance.hud.animator.SetTrigger("coverScreen");
            enabled = false;
        }
    }
    private void Start()
    {
        completedLevels = PlayerPrefs.GetInt("CompletedLevels", 1);
        Debug.Log($"{completedLevels}, COMPLETED LEVELS");
    }
}
