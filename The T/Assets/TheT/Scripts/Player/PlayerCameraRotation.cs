using UnityEngine;
using System.Collections;

public class PlayerCameraRotation : MonoBehaviour {

    [SerializeField] private Transform playerCameraHolder;

    int rotationSpeed = 10;
    float minYRotation = -90F;
    float maxYRotation = 90F;

    float yRotation = 0F;

    private void Update()
    {
        HandleCameraRotation();
    }

    private void HandleCameraRotation()
    {
        // Player X Rotation
        transform.Rotate(0, Input.GetAxis("Mouse X") * rotationSpeed, 0);

        // Camera Y Rotation
        yRotation += Input.GetAxis("Mouse Y") * rotationSpeed;
        yRotation = Mathf.Clamp(yRotation, minYRotation, maxYRotation);

        playerCameraHolder.transform.localEulerAngles = new Vector3(-yRotation, 0, 0);
    }
}
