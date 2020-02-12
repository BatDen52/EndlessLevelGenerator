using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Wallet))]
public class UI : MonoBehaviour
{
    [SerializeField] private Text _textScore;

    private void OnEnable()
    {
        GetComponent<Wallet>().GetingScore += PrintScore;
    }

    private void PrintScore(int score)
    {
        _textScore.text = score.ToString();
    }

    private void OnDisable()
    {
        GetComponent<Wallet>().GetingScore -= PrintScore;
    }
}
