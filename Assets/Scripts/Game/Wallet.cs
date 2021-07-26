using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wallet : MonoBehaviour
{
    public event UnityAction<int> ScoreChanged;

    private int _score;

    public int Score => _score;

    public void TakeCoin(int count)
    {
        _score += count;
        ScoreChanged?.Invoke(_score);
    }
}
