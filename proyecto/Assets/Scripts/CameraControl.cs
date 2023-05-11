using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivatePriority()
    {
        foreach (Transform child in transform)
            if(child.GetComponent<CinemachineVirtualCamera>())
                child.GetComponent<CinemachineVirtualCamera>().Priority = 10;
    }
}
