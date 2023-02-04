using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace ClueBoxes
{
    public class PopUpClue : MonoBehaviour
    {
        [SerializeField] ClueText[] unformattedText;
        [SerializeField] int clueIndex;
        [SerializeField] int minPeriodicClueIndex;
        [SerializeField] int maxPeriodicClueIndex;
        [SerializeField] private GameObject UI_parent;
        [SerializeField] private SpriteRenderer background;
        [SerializeField] private TextMeshProUGUI textField;
        [SerializeField] private Button closeButton;
        [SerializeField] private Collider2D triggerArea;
        [SerializeField] private GameObject clueIndicator;
        [SerializeField] private int NPCID;

        private void Start()
        {
            SetUpTrigger();
            AdjustSize();
        }

        private void TryToTrackVisit()
        {
            FindObjectOfType<LogicManager>().IncreaseVisitCount(NPCID);
        }
        private void SetUpTrigger()
        {
            if (triggerArea == null)
                Debug.LogError("No Collider for pup-up-clue on " + gameObject.name);
            else
                triggerArea.isTrigger = true;
        }

        private void AdjustSize()
        {
            TextWithDimensions textFormat = ClueBoxFormatter.Adjust(unformattedText[clueIndex].GetText());

            background.size = new Vector2(textFormat.width / 100f, textFormat.height / 100f);

            textField.text = textFormat.formattedText;
            textField.GetComponent<RectTransform>().sizeDelta = new Vector2(2 * textFormat.width, textFormat.height);

            Vector3 temp = closeButton.transform.position;
            temp.x = 0.5f * background.size.x - 0.18f;
            temp.y = -0.5f * background.size.y - 0.08f;
            closeButton.transform.localPosition = temp;
        }

        public void SetText(int newClueIndex)
        {
            clueIndex = newClueIndex;
            AdjustSize();
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            DisplayMessage();
            HideClueIndicator();
            TryToTrackVisit();
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            clueIndex++;
            if (clueIndex == maxPeriodicClueIndex)
            {clueIndex = minPeriodicClueIndex;}
            AdjustSize();

            HideMessage();
            ShowClueIndicator();
        }

        private void HideMessage()
        {
            UI_parent.SetActive(false);
        }

        private void DisplayMessage()
        {
            UI_parent.SetActive(true);
        }

        // For "close" button
        public void Close() => HideMessage();

        private void HideClueIndicator() => clueIndicator.gameObject.SetActive(false);
        private void ShowClueIndicator() => clueIndicator.gameObject.SetActive(true);
    }
}