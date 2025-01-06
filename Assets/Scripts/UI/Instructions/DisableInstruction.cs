using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInstruction : MonoBehaviour
{
     public Canvas doorInstruction, itemInstruction;
     
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorInstruction.gameObject.SetActive(false);
            itemInstruction.gameObject.SetActive(false);
        }
    }
}
