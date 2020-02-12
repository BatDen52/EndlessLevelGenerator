using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TakeCoin))]
public class Wallet : MonoBehaviour
{
    public event UnityAction<int> GetingScore;

    private int _score;

    public int Score => _score;

    private void OnEnable()
    {
        GetComponent<TakeCoin>().TakingCoin += OnTakingCoin;
    }

    public void OnTakingCoin(int count)
    {
        _score += count;
        GetingScore?.Invoke(_score);
    }

    private void OnDisable()
    {
        GetComponent<TakeCoin>().TakingCoin -= OnTakingCoin;
    }
}
