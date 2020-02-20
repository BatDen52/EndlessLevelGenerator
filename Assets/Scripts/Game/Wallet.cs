using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TakeCoin))]
public class Wallet : MonoBehaviour
{
    public event UnityAction<int> ScoreGeting;

    private int _score;
    private TakeCoin _takeCoin;

    public int Score => _score;

    private void OnEnable()
    {
        _takeCoin = GetComponent<TakeCoin>();
        _takeCoin.Taking += OnTaking;
    }

    private void OnDisable()
    {
        _takeCoin.Taking -= OnTaking;
    }

    public void OnTaking(int count)
    {
        _score += count;
        ScoreGeting?.Invoke(_score);
    }
}
