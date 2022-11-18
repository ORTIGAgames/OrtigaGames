using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraDrag : MonoBehaviour
{
    public float dragSpeed;

    public float outerLeft;
    public float outerRight;
    public float outerDown;
    public float outerUp;
    [SerializeField] CinemachineVirtualCamera camera;
    [SerializeField] CinemachineBrain worldcamera;
    public Manager game;
    Ray ray;
    RaycastHit hit;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.name);
            }
            else
            {
                worldcamera.ActiveVirtualCamera.Priority = 10;
                camera.gameObject.transform.position = worldcamera.gameObject.transform.position;
                worldcamera.m_DefaultBlend.m_Time = 0;
                camera.Priority = 100;

                var newPosition = new Vector3();
                newPosition.x = Input.GetAxis("Mouse X") * dragSpeed * Time.deltaTime;
                newPosition.y = Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;
                newPosition.z = newPosition.y;

                if (gameObject.transform.position.x > -outerLeft && gameObject.transform.position.x < outerRight && gameObject.transform.position.z > -outerDown && gameObject.transform.position.z < outerUp)
                    transform.Translate(-newPosition);
                if (gameObject.transform.position.x < -outerLeft || gameObject.transform.position.x > outerRight || gameObject.transform.position.z < -outerDown || gameObject.transform.position.z > outerUp)
                    transform.Translate(newPosition);
            }
        }       
    }
}
