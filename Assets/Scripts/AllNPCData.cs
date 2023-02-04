using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AllNpcList", order=1)]
public class AllNPCData : ScriptableObject
{
    [SerializeField]
    private NPCQuestMenuData[] NPCArray;
    public NPCQuestMenuData[] GetAllNPCData() { return NPCArray; }

}
