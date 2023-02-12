using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour 
{
    public void Open(Quaternion target, float speed)
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, target, speed);
    }

    public void Close()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
