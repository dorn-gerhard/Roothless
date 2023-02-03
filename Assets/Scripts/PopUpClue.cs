using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class PopUpClue : MonoBehaviour
{
    [SerializeField] ClueText unformattedText;
    [SerializeField] private GameObject UI_parent;
    [SerializeField] private SpriteRenderer background;
    [SerializeField] private TextMeshProUGUI textField;
    [SerializeField] private Button closeButton;

    private Collider2D triggerArea;

    private void Start()
    {
        SetUpTrigger();
        AdjustSize();
    }

    private void SetUpTrigger()
    {
        triggerArea = GetComponent<Collider2D>();
        if(triggerArea == null)
            Debug.LogError("No Collider for pup-up-clue on " + gameObject.name);
        else
            triggerArea.isTrigger = true;
    }

    private void AdjustSize()
    {
        TextWithDimensions textFormat = ClueBoxFormatter.Adjust(unformattedText.GetText());
        Debug.Log(textFormat);

        background.size = new Vector2(textFormat.width / 100f, textFormat.height / 100f);
        
        textField.text = textFormat.formattedText;
        textField.GetComponent<RectTransform>().sizeDelta = new Vector2(2 * textFormat.width, textFormat.height);

        Vector3 temp = closeButton.transform.position;
        temp.x = 0.5f * background.size.x - 0.18f;
        temp.y = -0.5f * background.size.y - 0.08f;
        closeButton.transform.localPosition = temp;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        DisplayMessage();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        HideMessage();
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
}