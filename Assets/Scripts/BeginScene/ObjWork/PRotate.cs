using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRotate : Rotate
{
    protected override void thisRotate()
    {
        transform.Rotate(Vector3.up,speed*Time.deltaTime);
        if (transform.eulerAngles.y > 90f)
        {
            speed = -speed;
        }else if (transform.eulerAngles.y < -10f)
        {
            speed = -speed;

        }
    }
}
