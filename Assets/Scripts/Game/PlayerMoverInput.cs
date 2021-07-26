using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverInput : MonoBehaviour
{
    [SerializeField] private Mover _player;

    private bool _isGrounded;

    private void Update()
    {
        _player.MoveLeft();

        if (_isGrounded && Input.GetKey(KeyCode.Space))
        {
            _player.Jump();
            _isGrounded = false;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            _player.MoveUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            _player.MoveDown();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ground>() != null)
            _isGrounded = true;
    }
}
