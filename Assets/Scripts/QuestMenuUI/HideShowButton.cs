using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HideShowButton : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private bool isHidden = false;
    private Image buttonImage;
    [SerializeField]
    private float moveDistance;
    [SerializeField]
    private float moveTimeS;
    private bool isMoving = false;
    RectTransform parentRectTransform;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        
        parentRectTransform = transform.parent.gameObject.GetComponent<RectTransform>();
        
    }

    public void ShowOrHide()
    {
        Sprite newSprite = isHidden ? sprites[0] : sprites[1];
        buttonImage.sprite = newSprite;
        MoveMenu();
    }

    public void MoveMenu()
    {
        if (isMoving) { return; }
        
        Vector3 moveVector = parentRectTransform.anchoredPosition;
        moveVector.x += moveDistance * (isHidden ? 1 : -1);

        StartCoroutine(SmoothMovement(moveVector));
    }


    private IEnumerator SmoothMovement(Vector3 moveVector)
    {
        isMoving = true;
        float currentTime = 0;
        while (currentTime < moveTimeS )
        {
            parentRectTransform.anchoredPosition = (currentTime / moveTimeS) * moveVector;

           
            currentTime += Time.deltaTime;
            yield return null;
        }
        isMoving = false;
        isHidden = isHidden ? false : true;
    }
    

    

}
