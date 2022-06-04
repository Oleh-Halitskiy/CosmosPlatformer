using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{

    [SerializeField] private AchievementPanel _panel;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private GameObject _completionPanel;
    [SerializeField] private Image image;

    // Start is called before the first frame update
    void Start()
    {
        _titleText.text = _panel.Title;
        _descriptionText.text = _panel.Description;
        image.sprite = _panel.Image;
    }
    // Update is called once per frame
    void Update()
    {
        if(!_panel.Completed)
        {
            _completionPanel.SetActive(true);
        }
        else
        {
            _completionPanel.SetActive(false);
        }
        _panel.Completed = Convert.ToBoolean(PlayerPrefs.GetString(_panel.Title, "FALSE"));
    }
}
