using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<GridObject>()?.Type == ObjectType.Barrier)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
