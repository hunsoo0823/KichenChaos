using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private GameInput gameInput;

    private bool iswalking = false;
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    public bool IsWalking(){
        return iswalking;
    }

    private void HandleInteractions()
    {
        Physics.Racast(transform.position)
    }

    private void HandleMovement()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRaidus = .7f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRaidus, moveDir, moveDistance);

        if (!canMove)
        {
            // Cannot move Toward moveDir

            // Attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRaidus, moveDirX, moveDistance);

            if (canMove)
            {
                // Can move only on the X
                moveDir = moveDirX;
            }
            else
            {
                // Cannot move only on the X

                // Attempt only Z movement
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRaidus, moveDirZ, moveDistance);

                if (canMove)
                {
                    // Can move only on the X
                    moveDir = moveDirZ;
                }
                else
                {
                    // Cannot move in any direction
                }

            }
        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        iswalking = moveDir != Vector3.zero;

        float rotatespeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, rotatespeed * Time.deltaTime);
    }
}
