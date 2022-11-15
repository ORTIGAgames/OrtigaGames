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

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * dragSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;

            if (gameObject.transform.position.x > -outerLeft)
            {

            }
        }

    }
}
