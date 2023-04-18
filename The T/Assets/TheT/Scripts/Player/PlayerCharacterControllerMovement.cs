using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterControllerMovement : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private CharacterController characterController;

    // Walk and Run
    private int currentSpeed = 10;
    private Vector3 walkDir;

    // Gravity
    private Vector3 fallingVelocityVector;
    private float standingVelocityValue = 0;
    [SerializeField] private float gravity = -30f;

    // Jump and Gravity
    [SerializeField] private float jumpHeight = .09f;

    // Sliding
    private bool willSlideOnSlopes = true;
    private float slopeSpeed = 8;
    private Vector3 hitPointNormal;
    private Vector3 slideDir;
    private bool IsSliding
    {
        get
        {
            //Debug.DrawRay(transform.position, Vector3.down, Color.blue);
            float maxDistance = 2f;
            if (characterController.isGrounded && Physics.Raycast(transform.position, Vector3.down, out RaycastHit slopeHit, maxDistance))
            //if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit slopeHit, maxDistance))
            //float rayCastRadius = 1f;
            //if (Physics.SphereCast(transform.position, rayCastRadius, Vector3.down, out RaycastHit slopeHit, maxDistance))
            {
                // Angle value of the floor
                hitPointNormal = slopeHit.normal;
                //Debug.Log(Vector3.Angle(hitPointNormal, Vector3.up));
                return Vector3.Angle(hitPointNormal, Vector3.up) > characterController.slopeLimit;
            } else
            {
                return false;
            }
        }
    }

    private void Update()
    {
        HandleMovement();
        HandleJumpAndGravity();
        HandleSlide();

        ApplyFinalMovements();
    }

    private void ApplyFinalMovements()
    {
        if (!IsSliding)
        {
            // Walk
            if (walkDir != Vector3.zero)
            {
                characterController.Move(walkDir * currentSpeed * Time.deltaTime);
            }

            // Jump
            characterController.Move(fallingVelocityVector);
        }

        if (IsSliding)
        {
            characterController.Move(slideDir * slopeSpeed * Time.deltaTime);
        }
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorSmoothed();
        walkDir = transform.right * inputVector.x + transform.forward * inputVector.y;
    }

    private void HandleJumpAndGravity()
    {
        if (characterController.isGrounded && fallingVelocityVector.y < 0)
        {
            fallingVelocityVector.y = standingVelocityValue;
        }

        if (!characterController.isGrounded)
        {
            fallingVelocityVector.y += gravity * Time.deltaTime * Time.deltaTime; // sqare of time
        }

        if (gameInput.IsJumping() && characterController.isGrounded)
        {
            fallingVelocityVector.y = jumpHeight;
        }
    }

    private void HandleSlide()
    {
        if(willSlideOnSlopes && IsSliding)
        {
            slideDir = new Vector3(hitPointNormal.x, -hitPointNormal.y, hitPointNormal.z) * slopeSpeed;
        }
    }
}
