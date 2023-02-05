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
        FindObjectOfType<LogicManager>().SubmitAcusation(_characterID);
    }

    public void SetData(NPCQuestMenuData newData)
    {
        _characterID = newData.NPCID;
        _characterMenuIcon = newData.NPCIcon;
        if(_characterMenuIcon != null)
        {
            GetComponentInChildren<Image>().sprite = _characterMenuIcon;
        }
        _characterName = newData.NPCName.GetText();
        GetComponentInChildren<TextMeshProUGUI>().text = _characterName;
    }
}
