using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] private GameObject _target;

    void Update()
    {
        transform.position = new Vector3(_target.transform.position.x, transform.position.y, transform.position.z);
    }
}
