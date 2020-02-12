using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeCoin : MonoBehaviour
{
    public event UnityAction<int> TakingCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GridObject>()?.Type == ObjectType.Coin)
        {
            Destroy(other.gameObject);
            TakingCoin?.Invoke(1);
        }
    }
}
