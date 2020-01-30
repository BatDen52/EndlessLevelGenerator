using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text _textScore;

    private void Start()
    {
        GetComponent<Wallet>().OnGetingScore += PrintScore;
    }
    private void PrintScore(int score)
    {
        _textScore.text = score.ToString();
    }
}
