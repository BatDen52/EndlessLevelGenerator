using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Wallet wallet = other.gameObject.GetComponent<Wallet>();
        
        if (wallet != null)
        {
            wallet.TakeCoin(1);
            Destroy(gameObject);
        }
    }
}
