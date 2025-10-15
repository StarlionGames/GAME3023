using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSceneUI : MonoBehaviour
{
    [SerializeField] GameObject canvas;
    public TextMeshProUGUI textBox;

    [Header("Buttons")]
    public Button AttackButton;
    public Button SkillButton;
    public Button FleeButton;

    [Header("Skills")]
    public ScrollRect SkillList;
    [SerializeField] GameObject SkillChoicePrefab;

    public void UpdateText(string newText)
    {
        if (!textBox.isActiveAndEnabled) 
        { 
            ClearCanvas();
            textBox.gameObject.SetActive(true);
        }
        textBox.text = newText;
    } 
    public void ShowPlayerActions()
    {
        AttackButton.gameObject.SetActive(true);
        SkillButton.gameObject.SetActive(true);
        FleeButton.gameObject.SetActive(true);

        Character curr = BattleSystem.instance.state.CurrentActiveCharacter;
        if (curr == null) {
            Debug.Log("Character is null!");
            return; }   

        AttackButton.onClick.AddListener(() => Attack(curr));
        SkillButton.onClick.AddListener(() => OpenSkills(curr));
    }
    public void ClearCanvas()
    {
        foreach(Transform child in canvas.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void Attack(Character character)
    {
        Debug.Log(character.name + " tried to attack!");
        character.AttackTarget(BattleSystem.instance.state.Enemy);
    }
    public void OpenSkills(Character character)
    {
        ClearCanvas();
        SkillList.gameObject.SetActive(true);

        RectTransform parent = SkillList.content;
        foreach (Skills s in character.skills)
        {
            GameObject button = Instantiate(SkillChoicePrefab, parent);
            button.GetComponentInChildren<TextMeshProUGUI>().text = s.name;
            button.GetComponent<Button>().onClick.AddListener(()=>SelectSkill(s, character));
        }
    }
    public void SelectSkill(Skills s, Character c)
    {
        s.UseSkill(c, BattleSystem.instance.state.Enemy);
        UpdateText(c.name + " used skill " + s.name + "!");

        
        BattleSystem.instance.SwitchTurns();
    }
    public void TryToFlee()
    {
        // add probability stuff later

        SceneManager.LoadScene("TestingScene");
    }
}
