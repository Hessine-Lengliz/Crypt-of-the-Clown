using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameObject InstructionTrigger;
    public Canvas Instruction;
    public Item Item;
      void OnTriggerStay(Collider other) {
        if (other.gameObject.CompareTag("Player")){
         if (Input.GetButtonDown("Interact")){
          Instruction.gameObject.SetActive(false);
            InventoryManager.Instance.Add(Item);
            Destroy(this.gameObject);
            Destroy(InstructionTrigger);
            
            
            

            
        }}
       
        
    }
   
    
}
