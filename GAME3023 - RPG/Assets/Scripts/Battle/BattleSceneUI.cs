using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSceneUI : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public TextMeshProUGUI textBox;
    public Button AttackButton, SkillButton, FleeButton;
    public ScrollRect SkillList;

    public void UpdateText(string newText)
    {
        if (!textBox.isActiveAndEnabled) { textBox.gameObject.SetActive(true); }
        textBox.text = newText;
    } 
    public void ShowPlayerActions()
    {
        AttackButton.gameObject.SetActive(true);
        SkillButton.gameObject.SetActive(true);
        FleeButton.gameObject.SetActive(true);
    }
    public void ClearCanvas()
    {
        foreach(Transform child in canvas.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void Attack()
    {
        
    }
    public void OpenSkills()
    {
        ClearCanvas();
        SkillList.gameObject.SetActive(true);
    }
    public void TryToFlee()
    {
        // add probability stuff later

        SceneManager.LoadScene("TestingScene");
    }
}
