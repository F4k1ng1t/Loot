using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class FlashlightBehavior : MonoBehaviour
{
    public GameObject Text;
    public Camera Camera;
    public PlayerBehavior PlayerBehavior;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Text.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Text.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(this.transform.parent.gameObject);

                Debug.Log("Flashlight acquired");

                AcquireFlashlight();
                Text.SetActive(false);
            }
        }
    }
    private void AcquireFlashlight()
    {
        PlayerBehavior.hasFlashlight = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Text.SetActive(false);
    }
}
    

