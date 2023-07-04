using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraController : MonoBehaviour
{
    public float PlayerCameraDistance { get; set; }
    public Transform cameraTarget;

    private Camera playerCamera;
    private float zoomSpeed = 35f;

    private void Start()
    {
        PlayerCameraDistance = 10f;
        playerCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetAxisRaw("Mouse ScrollWheel") != 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            playerCamera.fieldOfView -= scroll * zoomSpeed;
            playerCamera.fieldOfView = Mathf.Clamp(playerCamera.fieldOfView, 0, 85);
        }

        transform.position = new Vector3(cameraTarget.position.x, cameraTarget.position.y + PlayerCameraDistance, cameraTarget.position.z - PlayerCameraDistance);
    }
}
