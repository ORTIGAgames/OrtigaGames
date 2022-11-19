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
    [SerializeField] CinemachineVirtualCamera ncamera;
    [SerializeField] CinemachineBrain worldcamera;
    public Manager game;
    Ray ray;
    RaycastHit hit;
    public bool Activated;

    private void Awake()
    {
        Activated = true;
    }
    private void LateUpdate()
    {
        if (Input.GetMouseButton(0) && Activated && !worldcamera.IsBlending)
        {
            worldcamera.ActiveVirtualCamera.Priority = 10;
            ncamera.gameObject.transform.position = worldcamera.gameObject.transform.position;
            ncamera.Priority = 100;

            var newPosition = new Vector3();
            newPosition.x = Input.GetAxis("Mouse X") * dragSpeed * Time.deltaTime;
            newPosition.y = Input.GetAxis("Mouse Y") * dragSpeed * Time.deltaTime;
            newPosition.z = newPosition.y;

            if (gameObject.transform.position.x > -outerLeft && gameObject.transform.position.x < outerRight && gameObject.transform.position.z > -outerDown && gameObject.transform.position.z < outerUp)
                transform.Translate(-newPosition);
            if (gameObject.transform.position.x < -outerLeft || gameObject.transform.position.x > outerRight || gameObject.transform.position.z < -outerDown || gameObject.transform.position.z > outerUp)
                transform.Translate(newPosition);
        }


        if (!Activated)
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool hitted = Physics.Raycast(ray, out hit);
            if (hitted && hit.collider.GetComponent<Character>())
                StopAllCoroutines();
            if (!hitted || !hit.collider.GetComponent<Character>())
                StartCoroutine(Wait());         
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.2f);
        Activated = true;
    }
}
