using UnityEngine;

namespace ClueBoxes
{
    [CreateAssetMenu(menuName = "Clues/Clue Text")]
    public class ClueText : ScriptableObject
    {
        [TextArea]
        [SerializeField] string clueText;

        public string GetText() => clueText;
    }
}