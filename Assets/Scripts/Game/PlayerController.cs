using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMover _player;

    private bool _isGround;

    private void Update()
    {
        _player.MoveLeft();

        if (_isGround && Input.GetKey(KeyCode.Space))
        {
            _player.Jump();
            _isGround = false;
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
            _isGround = true;
    }
}
