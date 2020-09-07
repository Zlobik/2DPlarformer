using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] private Transform _door;
    [SerializeField] private float _openDoorSpeed;

    private bool _isOnDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            _isOnDoor = true;
        }
    }

    private void Update()
    {
        if (_isOnDoor)
        {
            _door.position = Vector3.MoveTowards(_door.position, new Vector3(_door.position.x - 3f, _door.position.y, _door.position.z), _openDoorSpeed * Time.deltaTime);

            if (_door.position.x <= 3f)
            {
                _isOnDoor = false;

                gameObject.SetActive(false);
            }
        }
    }
}
