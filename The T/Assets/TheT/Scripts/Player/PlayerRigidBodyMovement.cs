using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRigidBodyMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private GameInput gameInput;

    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float maxForce;

    private Vector3 moveDir;

    public void OnMove(InputAction.CallbackContext context)
    {
        
    }

    private void FixedUpdate()
    {
        // Find target velocity
        Vector3 currentVelocity = rigidBody.velocity;
        Vector3 targetVelocity = moveDir;
        targetVelocity *= speed;

        // Align direction
        targetVelocity = transform.TransformDirection(targetVelocity);

        // Calculate forces
        Vector3 velocityChange = (targetVelocity - currentVelocity);
        velocityChange.y = 0;

        // Limit force
        Vector3.ClampMagnitude(velocityChange, maxForce);

        // Apply
        rigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorSmoothed();
        //moveDir = transform.right * inputVector.x + transform.forward * inputVector.y;
        moveDir = new Vector3(inputVector.x, 0, inputVector.y);

        // Align direction
        //moveDir = transform.TransformDirection(moveDir);
    }
}
