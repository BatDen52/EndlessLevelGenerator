using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Wallet))]
public class UI : MonoBehaviour
{
    [SerializeField] private Text _textScore;

    private Wallet _wallet;

    private void OnEnable()
    {
        _wallet = GetComponent<Wallet>();
        _wallet.ChangedScore += PrintScore;
    }

    private void OnDisable()
    {
        _wallet.ChangedScore -= PrintScore;
    }

    private void PrintScore(int score)
    {
        _textScore.text = score.ToString();
    }
}
