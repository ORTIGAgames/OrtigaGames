using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovement : MonoBehaviour
{
    public float dragSpeed;
    public float outerRight;
    public float outerDown;
    public float outerUp;
    public float outerLeft;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * dragSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;

            //Esto es un limite para que cuando salgas no haga mas drag
            if (gameObject.transform.position.x > -outerLeft && gameObject.transform.position.x < outerRight && gameObject.transform.position.y > -outerDown && gameObject.transform.position.y < outerUp)
                transform.Translate(-newPosition);
            if (gameObject.transform.position.x < -outerLeft || gameObject.transform.position.x > outerRight ||  gameObject.transform.position.y < -outerDown || gameObject.transform.position.y > outerUp)
                transform.Translate(newPosition);
        }
    }
}
