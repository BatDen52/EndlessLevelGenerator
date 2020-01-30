using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    public event UnityAction<int> OnGetingScore;

    private int _score;

    public int Score => _score;

    private void Start()
    {
        GetComponent<TakeCoin>().OnTakingCoin += GetCoin;
    }

    public void GetCoin(int count)
    {
        _score += count;
        OnGetingScore?.Invoke(_score);
    }
}
