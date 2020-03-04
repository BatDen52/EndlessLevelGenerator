using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _speed;
    [SerializeField] private float _jumpForce;
    
    public float Speed => _speed.magnitude;

    public void Jump()
    {
        _rigidbody.velocity = new Vector3(_speed.x, _jumpForce, _rigidbody.velocity.z);
    }

    public void MoveUp()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _speed.z);
    }

    public void MoveDown()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, -1 * _speed.z);
    }

    public void MoveLeft()
    {
        _rigidbody.velocity = new Vector3(_speed.x, _rigidbody.velocity.y, 0);
    }
}
