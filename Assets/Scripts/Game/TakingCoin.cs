using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakingCoin : MonoBehaviour
{
    public event UnityAction<int> Taking;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Coin>() != null)
        {
            Destroy(other.gameObject);
            Taking?.Invoke(1);
        }
    }
}
