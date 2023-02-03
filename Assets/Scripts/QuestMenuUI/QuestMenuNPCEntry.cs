using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMenuNPCEntry : MonoBehaviour
{


    private int _characterID;
    private string _characterName;
    private Sprite _characterMenuIcon;
    [SerializeField]
    private GameObject accuseButton;
    [SerializeField]
    private QuestMenu _questMenu;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableAccusation()
    {
        accuseButton.SetActive(true);
    }

    public void DisableAccusation()
    {
        accuseButton.SetActive(false);
    }
    private void OnEnable()
    {
        _questMenu.onAcusePerson += EnableAccusation;
        _questMenu.onStopAcusing += DisableAccusation;
    }
    private void OnDisable()
    {
        _questMenu.onAcusePerson -= EnableAccusation;
        _questMenu.onStopAcusing -= DisableAccusation;
    }
}
