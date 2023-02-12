using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControl : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private bool _isCollision;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _isCollision = true;
            _signaling.UpVolume();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _isCollision = false;
            _signaling.DownVolume();
        }
    }
}