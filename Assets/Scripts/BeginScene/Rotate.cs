using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float speed;

    protected virtual void thisRotate()
    {
        transform.Rotate(Vector3.up, speed*Time.deltaTime);
    }
    
    void Update()
    {
        thisRotate();
    }
}
