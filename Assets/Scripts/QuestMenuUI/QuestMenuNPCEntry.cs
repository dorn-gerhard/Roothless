using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenuNPCEntry : MonoBehaviour
{


    private int _characterID;
    private string _characterName;
    private Sprite _characterMenuIcon;
    [SerializeField]
    private GameObject acuseButton;
    [SerializeField]
    private QuestMenu _questMenu;
    [SerializeField]
    private Image NPCIcon;
    public void SetQuestMenu(QuestMenu newQuestMenu)
    {
        _questMenu = newQuestMenu;
    }



    private void Start()
    {
        _questMenu.onAcusePerson += EnableAccusation;
        _questMenu.onStopAcusing += DisableAccusation;
    }


    public void EnableAccusation()
    {
        acuseButton.SetActive(true);
    }

    public void DisableAccusation()
    {
        acuseButton.SetActive(false);
    }
    private void OnEnable()
    {
        if (_questMenu != null)
        {
            _questMenu.onAcusePerson += EnableAccusation;
            _questMenu.onStopAcusing += DisableAccusation;
        }
       
    }
    private void OnDisable()
    {
        _questMenu.onAcusePerson -= EnableAccusation;
        _questMenu.onStopAcusing -= DisableAccusation;
    }

    public void Acuse()
    {
        Debug.Log("subbmitted accusation for character " + _characterName + " with character ID: " + _characterID); 
        FindObjectOfType<LogicManager>().SubmitAcusation(_characterID);
    }

    public void SetData(NPCQuestMenuData newData)
    {
        _characterID = newData.NPCID;
        _characterMenuIcon = newData.NPCIcon;
        _characterName = newData.NPCName.GetText();
        
    }

    public void DisplayCharacterIcon()
    {
        if (_characterMenuIcon != null)
        {
            NPCIcon.sprite = _characterMenuIcon;
        }
    }

    public void DisplayCharacterName()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = _characterName;
    }


}
