using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillzone : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<PlayerState>().Respawn();
            print("jag r�r");
        }
    }
}
