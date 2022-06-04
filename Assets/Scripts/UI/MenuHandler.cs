using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
/*Allows buttons to fire various functions, like QuitGame and LoadScene*/

public class MenuHandler : MonoBehaviour {

	[SerializeField] private string whichScene;
    [SerializeField] Inventory testInv;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(whichScene);
    }
    public void LoadLastSave()
    {
        if(File.Exists(Application.dataPath + "/save.json"))
        {
             string jsonSave = File.ReadAllText(Application.dataPath + "/save.json");
             SaveObject saveObject = JsonUtility.FromJson<SaveObject>(jsonSave);
             testInv.Container = saveObject.inventory;
             PlayerPrefs.SetInt("CurrentScore", saveObject.currentScore);
             SceneManager.LoadScene(saveObject.completedLevels);
        }

    }
}
