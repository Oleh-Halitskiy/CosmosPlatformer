using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
/*Allows buttons to fire various functions, like QuitGame and LoadScene*/

public class MenuHandler : MonoBehaviour {

	[SerializeField] private string whichScene;
    [SerializeField] Inventory testInv;
    [SerializeField] private AchievementsManager achievementsManager;
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
             achievementsManager.Achievements = saveObject.achievements;
             SceneManager.LoadScene(1);
        }

    }
}
