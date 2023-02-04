using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueIndicatorAnimator : MonoBehaviour
{
    enum FloatingState { BOTTOM, MIDDLE, TOP};

    Coroutine floating;
    Vector3 startPosition;
    int frameCounter = 0;
    FloatingState status;
    FloatingState previousStatus;

    [SerializeField] int framesToWait = 0;

    private void Awake()
    {
        startPosition = transform.position;
        status = FloatingState.MIDDLE;
        previousStatus = FloatingState.BOTTOM;
    }

    private void OnEnable()
    {
        floating = StartCoroutine(FloatClueIndicator());
    }

    private void OnDisable()
    {
        if(floating != null)
            StopCoroutine(floating);
    }

    private IEnumerator FloatClueIndicator()
    {
        while(true)
        {
            frameCounter = (frameCounter + 1) % framesToWait;
            if (frameCounter == 0)
                AdjustPosition();
            yield return new WaitForEndOfFrame();  
        }
    }

    private void AdjustPosition()
    {
        if (status == FloatingState.MIDDLE && previousStatus == FloatingState.BOTTOM)
        {
            transform.position += 0.01f * Vector3.up;
            previousStatus = status;
            status = FloatingState.TOP;
        }
        else if (status == FloatingState.MIDDLE && previousStatus == FloatingState.TOP)
        {
            transform.position -= 0.01f * Vector3.up;
            previousStatus = status;
            status = FloatingState.BOTTOM;
        }
        else if(status == FloatingState.BOTTOM)
        {
            transform.position += 0.01f * Vector3.up;
            previousStatus = status;
            status = FloatingState.MIDDLE;
        }
        else if(status == FloatingState.TOP)
        {
            transform.position -= 0.01f * Vector3.up;
            previousStatus = status;
            status = FloatingState.MIDDLE;
        }
    }
}