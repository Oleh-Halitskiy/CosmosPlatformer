using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Loads a new scene, while also clearing level-specific inventory!*/

public class SceneLoadTrigger : MonoBehaviour
{
    private int completedLevels;
    [SerializeField] string loadSceneName;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == NewPlayer.Instance.gameObject)
        {
            PlayerPrefs.SetInt("CompletedLevels", ++completedLevels);
            GameManager.Instance.hud.loadSceneName = loadSceneName;
            GameManager.Instance.hud.animator.SetTrigger("coverScreen");
            enabled = false;
        }
    }
    private void Start()
    {
        completedLevels = PlayerPrefs.GetInt("CompletedLevels");
    }
}
