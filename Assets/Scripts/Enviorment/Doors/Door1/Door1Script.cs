using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door1Script : MonoBehaviour
{
     public AudioSource doorOpenSound;
    public AudioSource doorCloseSound;
private void Start() {
    animator.SetBool("isOpened", false);
}
     public Canvas Instruction;
    public Animator animator;
    private bool DoorOpened = false;
      void OnTriggerStay(Collider other)
    {
        
                
        if (InventoryManager.Instance.IsKey1Acquired())
        {
             Instruction.gameObject.SetActive(true);
             Debug.Log("iskeyaquiredCondition");
        {
            if (Input.GetButtonDown("Interact"))
            {
                animator.SetBool("isOpened", true);
                Instruction.gameObject.SetActive(false);
                 

            }
        }

    }
    
}  


 void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instruction.gameObject.SetActive(false);
            animator.SetBool("isOpened", false);
            
        }
    }
// 
// 
public void openningDoor(){
doorOpenSound.Play();
}
public void closingDoor(){
doorCloseSound.Play();
}
}
