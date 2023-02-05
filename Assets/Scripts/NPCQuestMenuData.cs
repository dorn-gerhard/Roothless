using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ClueBoxes;

[CreateAssetMenu(fileName = "NPCQuestMenuData", menuName = "ScriptableObjects/NPCQuestMenuData", order = 1)]
public class NPCQuestMenuData : ScriptableObject
{
    
    public ClueText NPCName;
    public int NPCID;
    public Sprite NPCIcon;
    public bool nameIsKnown = false;

}
