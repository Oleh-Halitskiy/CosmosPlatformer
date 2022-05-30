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
    [SerializeField] public List<InventorySlot> inventory;
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
        saveObject.AchievementsSave();
        string JsonSave = JsonUtility.ToJson(saveObject);
        File.WriteAllText(Application.dataPath + "/save.json", JsonSave);
        Debug.Log(JsonSave);
    }
    public void AchievementButton()
    {
        Debug.Log("You're now in new window");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Unpause();
        }
    }
}

