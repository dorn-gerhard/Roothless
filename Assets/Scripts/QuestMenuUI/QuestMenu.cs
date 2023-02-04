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


    [SerializeField]
    GameObject NPCMenuEntryPrefab;
    [SerializeField]
    private float initialSpawnLocation;
    [SerializeField]
    private float spawnLocationIncrement;
    private int currentNPCEntryCount = 0;
    [SerializeField]
    private float offsetToRight=105;

    void Start()
    {
        
        onAcusePerson += SwitchAcusationButton;
        onStopAcusing += SwitchAcusationButton;

        CreateNewNPCEntry(0);
        CreateNewNPCEntry(1);

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

    private void CreateNewNPCEntry(int NPCID)
    {
        QuestMenuNPCEntry newEntry = Instantiate(NPCMenuEntryPrefab, new Vector3(offsetToRight, initialSpawnLocation - (spawnLocationIncrement*currentNPCEntryCount)), Quaternion.identity, transform).GetComponent<QuestMenuNPCEntry>();
        SetUpNewEntry(newEntry, NPCID);
        currentNPCEntryCount++;

    }
    private void SetUpNewEntry(QuestMenuNPCEntry newEntry, int NPCID)
    {
        NPCQuestMenuData menuData = FindObjectOfType<LogicManager>().allNPCData.GetAllNPCData()[NPCID];
        newEntry.SetData(menuData);
        newEntry.SetQuestMenu(this);

    }
}
