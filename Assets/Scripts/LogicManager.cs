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
    private int NPCsVisited = 0;
    private int[] NPCVisitOrder;


    // Start is called before the first frame update
    void Start()
    {
        playerVisitCount = new int[allNPCData.GetAllNPCData().Length];
        for(int i = 0; i< allNPCData.GetAllNPCData().Length; i++ )
        {
            playerVisitCount[i] = 0;
        }

        NPCVisitOrder = new int[allNPCData.GetAllNPCData().Length];
        for (int i = 0; i < allNPCData.GetAllNPCData().Length; i++)
        {
            NPCVisitOrder[i] = -1;
        }
    }

    public void EnableCharacterName(int NPCID)
    {
        if (NPCID >= playerVisitCount.Length) { return; }
        questMenu.EnableCharacterName(NPCVisitOrder[NPCID]);
    }
    public void IncreaseVisitCount(int idx)
    {
        if(idx >= playerVisitCount.Length) { return; }
        playerVisitCount[idx]++;
        if(NPCsVisited< playerVisitCount.Length)
        {
            InitiateNewMenuEntry(idx);
        }
        
    }

    public void InitiateNewMenuEntry(int idx)
    {
        
        if (playerVisitCount[idx]==1)
        {
            //Debug.Log("MakeEntry");
            questMenu.CreateNewNPCEntry(allNPCData.GetAllNPCData()[idx]);
            NPCVisitOrder[idx] = NPCsVisited;
            NPCsVisited++;
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
