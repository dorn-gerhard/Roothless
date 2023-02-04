using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSetUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CinemachineVirtualCamera vCam = GetComponent<CinemachineVirtualCamera>();
        vCam.Follow = FindObjectOfType<PlayerController>().gameObject.transform;
    }

}