using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraSetUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CinemachineVirtualCamera vCam = GetComponent<CinemachineVirtualCamera>();
        try
        {
            vCam.Follow = FindObjectOfType<PlayerController>().gameObject.transform;
        }
        catch(NullReferenceException ex)
        {
            // do nothing
        }
    }

}