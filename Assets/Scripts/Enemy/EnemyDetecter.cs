using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetecter : MonoBehaviour
{
    public AudioSource breath;
    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Enemy")){
            breath.Play();
            Debug.Log("enemyDetected");
        }
        else {
            breath.Stop();
            // Debug.Log("NotDetected");
        }
    }
}
