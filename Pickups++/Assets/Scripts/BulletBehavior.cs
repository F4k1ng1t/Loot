using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class BulletBehavior : MonoBehaviour
{

    public Camera Main_Camera;
    public GameObject Player;
    
    public float onScreenDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, onScreenDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
