using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
 

public class KeyBehavior : MonoBehaviour
{
    public GameObject Text;
    public Camera Camera;
    public GameBehavior gameManager;
    public PlayerBehavior PlayerBehavior;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }
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

                Debug.Log("Key acquired");

                AcquireKey();
                Text.SetActive(false);
                gameManager.Keys += 1;
                gameManager.currentKeys += 1;
                gameManager.PrintLootReport();
            }
        }
    }
    private void AcquireKey()
    {
        PlayerBehavior.hasKey = true;
    }
    private void OnTriggerExit(Collider other)
    {
        Text.SetActive(false);
    }
}


