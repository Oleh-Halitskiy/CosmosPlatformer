using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoreScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI YourScore;
    [SerializeField] TextMeshProUGUI BestScore;
    // Start is called before the first frame update
    void Start()
    {
        YourScore.text = "Your score: " + PlayerPrefs.GetInt("CurrentScore",0).ToString();
        if(PlayerPrefs.GetInt("CurrentScore",0) > PlayerPrefs.GetInt("BestScore",0))
        {
            PlayerPrefs.SetInt("BestScore", PlayerPrefs.GetInt("CurrentScore", 0));
        }
        BestScore.text = "Best score: " + PlayerPrefs.GetInt("BestScore", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
