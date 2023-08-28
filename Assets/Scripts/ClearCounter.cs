using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform CounterTopPoint;

    public void Interact(){
        Debug.Log("Interact");
        Transform kitchenobjectTransform = Instantiate(kitchenObjectSO.prefab, CounterTopPoint);
        kitchenobjectTransform.localPosition = Vector3.zero;

        Debug.Log(kitchenobjectTransform.GetComponent<KitchenObject>().GetKitchenObjectSO().objectName);
    }
}
