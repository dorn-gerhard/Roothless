using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClueBoxes;
public class LogicManager : MonoBehaviour
{

    [SerializeField]
    private int _correctChoiceNPCID = 1;
    [SerializeField]
    public AllNPCData allNPCData;

    [SerializeField] int[] clueIndexVector;

    [SerializeField]
    private QuestMenu questMenu;

    [SerializeField] PopUpClue[] npcGameobjects;
    [SerializeField] PopUpClue[] npcNamesClues;


    private const int ALI = 0;
    private const int BABSI = 1;
    private const int GERD = 2;
    private const int JEFF = 3;
    private const int TAMI = 4;
    private const int YAKOTA = 5;
    private const int COFFEE = 6;
    private const int RING = 7;


    [SerializeField]
    private int[] playerVisitCount;
    private int NPCsVisited = 0;
    private int[] NPCVisitOrder;


    // Start is called before the first frame update
    void Start()
    {
        playerVisitCount = new int[npcGameobjects.Length];
        for(int i = 0; i< npcGameobjects.Length; i++ )
        {
            playerVisitCount[i] = 0;
        }

        NPCVisitOrder = new int[npcGameobjects.Length];
        for (int i = 0; i < npcGameobjects.Length; i++)
        {
            NPCVisitOrder[i] = -1;
            
        }
        
        clueIndexVector = new int[npcGameobjects.Length];
        for (int i = 0; i < npcGameobjects.Length; i++)
        {
            clueIndexVector[i] = 0;
        }
        for (int i = 0; i < allNPCData.GetAllNPCData().Length; i++)
        {
            allNPCData.GetAllNPCData()[i].nameIsKnown = false;
        }
    }

    public void UpdateLogic()
    {
        
        if (playerVisitCount[ALI] == 1)
        {
            Debug.Log("update Jeffs min max");
            if (npcGameobjects[JEFF].maxPeriodicClueIndex < 3)
            {   
                npcGameobjects[JEFF].minPeriodicClueIndex = 1;
                npcGameobjects[JEFF].maxPeriodicClueIndex = 3;
                npcGameobjects[JEFF].clueIndex = 1;
            }
            
           
        }
        if (playerVisitCount[BABSI] == 3)
        {
            npcGameobjects[COFFEE].gameObject.SetActive(true);
        }
        if (playerVisitCount[COFFEE] == 1)
        {
            // activate ring
            npcGameobjects[RING].gameObject.SetActive(true);
        }        
        // activate coffee drink

        if (playerVisitCount[RING] == 1)
        {
            if (npcGameobjects[COFFEE].maxPeriodicClueIndex < 2)
            {   
                npcGameobjects[COFFEE].minPeriodicClueIndex = 1;
                npcGameobjects[COFFEE].maxPeriodicClueIndex = 2;
                npcGameobjects[COFFEE].clueIndex = 1;
            }
            
        }

        if (clueIndexVector[COFFEE] == 1)
        {
        if (npcGameobjects[BABSI].maxPeriodicClueIndex < 4)
            {   
                npcGameobjects[BABSI].minPeriodicClueIndex = 1;
                npcGameobjects[BABSI].maxPeriodicClueIndex = 4;
                npcGameobjects[BABSI].clueIndex = 3;
            }
        }

        if (playerVisitCount[BABSI] == 2)
        {
            if (!npcNamesClues[TAMI].gameObject.activeInHierarchy)
            {
                npcNamesClues[TAMI].gameObject.SetActive(true);
            }
            allNPCData.GetAllNPCData()[TAMI].nameIsKnown = true;
            if (playerVisitCount[TAMI] > 0)
            {
                EnableCharacterName(TAMI);
            }
        }

        if (playerVisitCount[YAKOTA] == 1)
        {
            if (!npcNamesClues[GERD].gameObject.activeInHierarchy)
            {
                npcNamesClues[GERD].gameObject.SetActive(true);
            }
            allNPCData.GetAllNPCData()[GERD].nameIsKnown = true;
            if (playerVisitCount[GERD] > 0)
            {
                EnableCharacterName(GERD);
            }
        }

        if (playerVisitCount[ALI] == 1)
        {
            if (!npcNamesClues[JEFF].gameObject.activeInHierarchy)
            {
                npcNamesClues[JEFF].gameObject.SetActive(true);
            }
            allNPCData.GetAllNPCData()[JEFF].nameIsKnown = true;
            if (playerVisitCount[JEFF] > 0)
            {
                EnableCharacterName(JEFF);
            }
        }
         

    }

    public void EnableCharacterName(int NPCID)
    {
        if (NPCID >= playerVisitCount.Length) { return; }
        questMenu.EnableCharacterName(NPCVisitOrder[NPCID]);
    }

    public void IncreaseVisitCount(int idx, int clueIndex)
    {
        if(idx < 100) { 
            playerVisitCount[idx]++;
            clueIndexVector[idx] = clueIndex;
        }

        if(NPCsVisited < allNPCData.GetAllNPCData().Length && idx < allNPCData.GetAllNPCData().Length)
        {
            InitiateNewMenuEntry(idx);
        }
        if (idx != 999)
        {
            Debug.Log("Player: " + idx + ", visited: " + playerVisitCount[idx] + ", Clue: " + clueIndex);
        }
        UpdateLogic();
        
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
