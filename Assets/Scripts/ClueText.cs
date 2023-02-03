using UnityEngine;

[CreateAssetMenu(menuName = "Clues/Clue Text")]
public class ClueText : ScriptableObject
{
    [SerializeField] string clueText;

    public string GetText() => clueText;
}