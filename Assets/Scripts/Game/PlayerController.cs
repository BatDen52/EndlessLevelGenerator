using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Vector3 _speed;
    [SerializeField] private float _jumpForce;

    private bool _isGround;

    public float Speed => _speed.x;

    void Update()
    {
        _rigidbody.velocity = new Vector3(_speed.x, 
            Convert.ToInt32(_isGround && Input.GetKey(KeyCode.Space)) == 0 ? _rigidbody.velocity.y : _jumpForce,
            (Convert.ToInt32(Input.GetKey(KeyCode.W)) - Convert.ToInt32(Input.GetKey(KeyCode.S))) * _speed.z);

        if (_isGround && Input.GetKey(KeyCode.Space))
            _isGround = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<GridObject>()?.Layer == GridLayer.Ground)
            _isGround = true;
    }
}
