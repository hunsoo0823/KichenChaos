using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    
    private void Awake(){
        playerInputAction = new PlayerInputAction();
        playerInputAction.Player.Enable();
    }
    public Vector2 GetMovementVectorNormalized(){

        Vector2 inputVector = playerInputAction.Player.Move.ReadValue<Vector2>();
        
        inputVector = inputVector.normalized;
        Debug.Log(inputVector);

        return inputVector;
    }
}
