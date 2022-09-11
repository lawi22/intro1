using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Killbox : MonoBehaviour
{

    GameObject gameobjectToKill;

    private void Start()
    {
        gameobjectToKill = gameObject.transform.parent.gameObject;
        //G�r in p� transform, fr�gar vem som �r parent, tar sedan dess game object (Ghost)


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true) {
            if (collision.gameObject.GetComponent<PlayerMovement>().IsFalling() == true)
            {
                
                gameObject.GetComponentInParent<Enemy_GhostMovement>().KillMe();
            }
            
        }
    }
}
