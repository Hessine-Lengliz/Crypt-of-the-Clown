using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnOff : MonoBehaviour
{
    [Header("Light")]
    private bool isLightEnabled = false;
    private Light lightComponent;
    private Renderer flashlightRenderer;

    public AudioSource OnSound;
    public AudioSource OffSound;


    void Start()
    {
        lightComponent = GetComponentInChildren<Light>();
        flashlightRenderer = GetComponent<Renderer>(); // Assuming the flashlight mesh has a Renderer component.
        flashlightRenderer.enabled = false;
        lightComponent.enabled = false;

    }

    void Update()
    {
        FlashEnable();
    }

    void FlashEnable()
    {

        if (InventoryManager.Instance.IsFlashlightAcquired())
        {


            {
                if (Input.GetButtonDown("Flash"))
                {
                    isLightEnabled = !isLightEnabled;
                    lightComponent.enabled = isLightEnabled;
                    flashlightRenderer.enabled = isLightEnabled;
                    if(isLightEnabled){
                        OnSound.Play();
                    }
                    else if(!isLightEnabled){
                        OffSound.Play();
                    }
                }
            }

        }
    }
}
