using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleSceneUI : MonoBehaviour
{
    BattleState battleState;

    [SerializeField] GameObject canvas;
    public TextMeshProUGUI textBox;

    [Header("Buttons")]
    public Button AttackButton;
    public Button SkillButton;
    public Button FleeButton;

    [Header("Skills")]
    public ScrollRect SkillList;
    [SerializeField] GameObject SkillChoicePrefab;

    public static Action<BattleSceneUI> OnBattleUIAwake;

    private void OnEnable()
    {
        BattleState.OnBattleStateAwake += GetBattleState;
    }
    private void OnDisable()
    {
        BattleState.OnBattleStateAwake -= GetBattleState;
        OnBattleUIAwake = null;
    }
    private void Start()
    {
        Party curr = battleState.CurrentActiveCharacter;
        if (curr == null)
        {
            Debug.Log("Character is null!");
            return;
        }

        AttackButton.onClick.AddListener(() => Attack(curr));
        SkillButton.onClick.AddListener(() => OpenSkills(curr));

        OnBattleUIAwake?.Invoke(this);
    }
    void GetBattleState(BattleState currBattleState) => battleState = currBattleState;
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
    }
    public void ClearCanvas()
    {
        foreach(Transform child in SkillList.content.transform)
        {
            Destroy(child.gameObject);
        }
        foreach(Transform child in canvas.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void Attack(Party c)
    {
        BattleState.PlayerTurn += () => UpdateText(c.name + " attacked!");
        BattleState.PlayerTurn += () => c.AttackTarget(battleState.Enemy);
        BattleSystem.OnTurnBegin?.Invoke();
        // later, be able to select enemies rather than just having one
    }
    public void OpenSkills(Party character)
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
    public void SelectSkill(Skills s, Party c)
    {
        BattleState.PlayerTurn += () => UpdateText(c.name + " used the skill " + s.name + "!");
        BattleState.PlayerTurn += () => s.UseSkill(c, battleState.Enemy);
        BattleSystem.OnTurnBegin?.Invoke();
    }
    public void CloseSkillList()
    {
        ClearCanvas();
        ShowPlayerActions();
    }
    public void TryToFlee()
    {
        // add probability stuff later

        GameManager.instance.sceneLoader.LoadNextScene((int)SceneDirectory.Battle,SceneDirectory.PlainsCenter);
        GameManager.instance.audioManager.ChangeBGM(AudioDirectory.OverworldMusic);
    }
}
