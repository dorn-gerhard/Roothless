using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicManager : MonoBehaviour
{

    [SerializeField]
    private int _correctChoiceNPCID = 1;
    [SerializeField]
    public AllNPCData allNPCData;
    

    // Start is called before the first frame update
    void Start()
    {
        
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
