using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

/*Disables the cursor, freezes timeScale and contains functions that the pause menu button can use*/ 

public class PauseMenu : MonoBehaviour
{
    [SerializeField] AudioClip pressSound;
    [SerializeField] AudioClip openSound;
    [SerializeField] GameObject pauseMenu;
    [SerializeField] private GameObject AchievementWindow;
    private SaveObject saveObject;
    // Use this for initialization
    void OnEnable()
    {
        Cursor.visible = true;
        GameManager.Instance.audioSource.PlayOneShot(openSound);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        Cursor.visible = false;
        gameObject.SetActive(false);
        GameManager.Instance.audioSource.PlayOneShot(openSound);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        PlayerPrefs.SetInt("CurrentScore",0);
        PlayerPrefs.SetInt("CompletedLevels",1);
        NewPlayer.Instance.PlayerInventory.Container.Clear();
        SceneManager.LoadScene("Menu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Save()
    {
        saveObject = new SaveObject();
        saveObject.InventorySave();
        string JsonSave = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.json", JsonSave);
        Debug.Log(JsonSave);
    }
    public void AchievementButton()
    {
        if (AchievementWindow.activeInHierarchy)
        {
            AchievementWindow.SetActive(false);
        }
        else
        {
            AchievementWindow.SetActive(true);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Unpause();
        }
    }
}

