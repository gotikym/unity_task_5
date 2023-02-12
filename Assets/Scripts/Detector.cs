using UnityEngine;

public class Detector : MonoBehaviour
{
    [SerializeField] private Door _leftDoor;
    [SerializeField] private Door _rightDoor;
    [SerializeField] private Quaternion _targetLeftDoorOpen;
    [SerializeField] private Quaternion _targetRightDoorOpen;
    [SerializeField] private float _speed;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _leftDoor.Open(_targetLeftDoorOpen, _speed);
            _rightDoor.Open(_targetRightDoorOpen, _speed);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Rogue>(out Rogue rogue))
        {
            _leftDoor.Close();
            _rightDoor.Close();
        }
    }
}
