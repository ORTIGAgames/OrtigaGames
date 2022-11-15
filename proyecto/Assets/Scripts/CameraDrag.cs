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

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            worldcamera.ActiveVirtualCamera.Priority = 10;
            camera.gameObject.transform.position = worldcamera.gameObject.transform.position;
            camera.Priority = 100;

            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * dragSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;

            if (gameObject.transform.position.x > -outerLeft && gameObject.transform.position.x < outerRight && gameObject.transform.position.z > -outerDown && gameObject.transform.position.z < outerUp)
                transform.Translate(-newPosition);
            if (gameObject.transform.position.x < -outerLeft || gameObject.transform.position.x > outerRight || gameObject.transform.position.z < -outerDown || gameObject.transform.position.z > outerUp)
                transform.Translate(newPosition);



        }

    }
}
