using UnityEngine;
using System.Collections;

public class PlayerControlling : MonoBehaviour {

    [SerializeField] private GameObject Player;

    [SerializeField] private int walkSpeed = 10;
    [SerializeField] private int runSpeed = 20;
    [SerializeField] private int currentSpeed = 10;

    [SerializeField] private int jumpHeight = 10;
	
	private void Update () {

        // Jumping
        if (Input.GetKeyDown(KeyCode.O))
        {
            Player.transform.position += Player.transform.up * jumpHeight * Time.deltaTime;
        }

        HandleWalk();
    }

    private void HandleWalk() 
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        if (Input.GetKey(KeyCode.I))
        {
            Player.transform.position += Player.transform.forward * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.K))
        {
            Player.transform.position -= Player.transform.forward * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.J))
        {
            Player.transform.position -= Player.transform.right * currentSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.L))
        {
            Player.transform.position += Player.transform.right * currentSpeed * Time.deltaTime;
        }
    }
}