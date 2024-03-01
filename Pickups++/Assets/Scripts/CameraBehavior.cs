using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public Vector3 camOffset = new Vector3(0f,1.2f,-2.6f);

    private Transform target;
    
    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player").transform;
    }
    private void LateUpdate()
    {
        this.transform.position = target.TransformPoint(camOffset);
        this.transform.LookAt(target);
    }
}
