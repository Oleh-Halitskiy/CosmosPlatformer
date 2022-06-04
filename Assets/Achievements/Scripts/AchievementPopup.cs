using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementPopup : MonoBehaviour
{
    private Achievement _achievement;
    [SerializeField] TextMeshProUGUI _title;
    [SerializeField] TextMeshProUGUI _description;
    private Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.instance.onAchievementComplete += HandleAchievement;
        _animator = GetComponent<Animator>(); 
    }
    private void HandleAchievement(Achievement ach)
    {
        _achievement = ach;
        _title.text = _achievement.Title;
        _description.text = _achievement.Description;
        StartCoroutine(ShowHidePopup());
    }
    private IEnumerator ShowHidePopup()
    {
        _animator.SetBool("IsShowing", true);
        yield return new WaitForSeconds(9);
        _animator.SetBool("IsShowing", false);
    }
}
