using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;




public class QuestMenu : MonoBehaviour
{

    private bool _canAcusePerson = true;
    private bool _isAcusing = false;
    public delegate void OnAcusePerson();
    public event OnAcusePerson onAcusePerson;
    public event OnAcusePerson onStopAcusing;
    [SerializeField]
    private Button acuseButton;
    [SerializeField]
    private string _acuseText;
    [SerializeField]
    private Sprite _acuseSprite;
    [SerializeField]
    private string _stopAcuseText;
    [SerializeField]
    private Sprite _stopSprite;
    [SerializeField] AudioSource audioSource;

    private int currentNPCEntryCount = 0;


    void Start()
    {
        onAcusePerson += SwitchAcusationButton;
        onStopAcusing += SwitchAcusationButton;

    }

    public void AcuseButtonPress()
    {
        if (_isAcusing)
        {
            onStopAcusing?.Invoke();
            _isAcusing = false;
        } else
        {
            onAcusePerson?.Invoke();
            if(SettingsManager.Instance.SoundIsOn)
                audioSource.Play();
            _isAcusing = true;
        }
    }
    private void SwitchAcusationButton()
    {
        string textUpdate = _isAcusing ?  _acuseText : _stopAcuseText;
        acuseButton.GetComponentInChildren<TextMeshProUGUI>().text = textUpdate;
        Sprite spriteUpdate = _isAcusing ? _acuseSprite : _stopSprite;
        acuseButton.GetComponentInChildren<Image>().sprite = spriteUpdate;
    }

    public void CreateNewNPCEntry(NPCQuestMenuData menuData)
    {
        transform.GetChild(currentNPCEntryCount + 1).gameObject.SetActive(true);
        QuestMenuNPCEntry newEntry = transform.GetChild(currentNPCEntryCount +1).GetComponent<QuestMenuNPCEntry>();
        SetUpNewEntry(newEntry, menuData);
        currentNPCEntryCount++;

    }
    private void SetUpNewEntry(QuestMenuNPCEntry newEntry, NPCQuestMenuData menuData)
    {
        
        newEntry.SetData(menuData);
        newEntry.SetQuestMenu(this);
        newEntry.DisplayCharacterIcon();
        if (menuData.nameIsKnown)
        {
            newEntry.DisplayCharacterName();
        }

    }
    public void EnableCharacterName(int childIdx) 
    {
        transform.GetChild(childIdx+1).GetComponent<QuestMenuNPCEntry>().DisplayCharacterName();
    }

}
