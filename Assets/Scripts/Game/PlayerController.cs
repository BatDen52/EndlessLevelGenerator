using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speedX;
    [SerializeField] private float _speedZ;
    [SerializeField] private float _jumpForce;

    private bool _isGround;

    public float Speed => _speedX;

    void Update()
    {
        _rigidbody.velocity = new Vector3(Speed, _rigidbody.velocity.y, _rigidbody.velocity.z);

        if (_isGround && Input.GetKey(KeyCode.Space))
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isGround = false;
        }
        else
        if (Input.GetKey(KeyCode.W))
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _speedZ);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, -1 * _speedZ);
        }
        else
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<GridObject>()?.Layer == GridLayer.Ground)
            _isGround = true;
    }
}
