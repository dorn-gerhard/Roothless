using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{

    [SerializeField]
    private int _correctChoiceNPCID = 1;
    [SerializeField]
    public AllNPCData allNPCData;

    [SerializeField]
    private QuestMenu questMenu;



    [SerializeField]
    private int[] playerVisitCount;


    // Start is called before the first frame update
    void Start()
    {
        playerVisitCount = new int[allNPCData.GetAllNPCData().Length];
        for(int i = 0; i< allNPCData.GetAllNPCData().Length; i++ )
        {
            playerVisitCount[i] = 0;
        }
    }

    public void IncreaseVisitCount(int idx)
    {
        if(idx >= playerVisitCount.Length) { return; }
        playerVisitCount[idx]++;
        InitiateNewMenuEntry(idx);
    }

    public void InitiateNewMenuEntry(int idx)
    {
        
        
        if (playerVisitCount[idx]==1)
        {
            Debug.Log("MakeEntry");
            questMenu.CreateNewNPCEntry(allNPCData.GetAllNPCData()[idx]);
        }
        
    }

 
    // Update is called once per frame
    void Update()
    {
        
    }


    public void SubmitAcusation(int NPCID)
    {
        if(NPCID == _correctChoiceNPCID)
        {
            TriggerPositiveSceneConclusion();
        } else
        {
            TriggerNegativeSceneConclusion();
        }
    }

    private void TriggerPositiveSceneConclusion()
    {
        Debug.Log("Win");
    }
    private void TriggerNegativeSceneConclusion()
    {
        Debug.Log("Lose");
    }
}
