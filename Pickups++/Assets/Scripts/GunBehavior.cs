using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public GameObject Text;

    public PlayerBehavior PlayerBehavior;


    private void OnTriggerEnter(Collider other) //displays interaction text
    {
        if (other.gameObject.name == "Player")
        {
            Text.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other) //waits for input to pick up the gun
    {
        if (other.gameObject.name == "Player")
        {
            Text.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                Destroy(this.transform.parent.gameObject);

                Debug.Log("Gun acquired");

                AcquireGun();
                Text.SetActive(false);
            }
        }
    }
    private void AcquireGun() //adds gun to inventory
    {
        PlayerBehavior.hasGun = true;
    }
    private void OnTriggerExit(Collider other) //removes interaction text
    {
        if (other.gameObject.name == "Player")
        {
            Text.SetActive(false);
        }
    }
}


