using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TakeCoin : MonoBehaviour
{
    public event UnityAction<int> OnTakingCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GridObject>()?.Type == ObjectType.Coin)
        {
            Destroy(other.gameObject);
            OnTakingCoin?.Invoke(1);
        }
    }
}
