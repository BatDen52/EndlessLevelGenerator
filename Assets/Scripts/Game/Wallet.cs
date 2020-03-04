using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    public event UnityAction<int> ChangedScore;

    private int _score;

    public int Score => _score;

    public void TakeCoin(int count)
    {
        _score += count;
        ChangedScore?.Invoke(_score);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Coin>() != null)
        {
            Destroy(other.gameObject);
            TakeCoin(1);
        }
    }
}
