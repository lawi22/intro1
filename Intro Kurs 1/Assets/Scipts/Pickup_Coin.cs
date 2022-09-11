using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Coin : MonoBehaviour
{

    [SerializeField] private ParticleSystem particles;

    private bool removeGameObject = false;
    private float timer;
    [SerializeField] private float timeBeforeDeletion = 1f;
    private bool canPickupCoin = true;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip pickUpClip;


    private void Update()
    {
        if (removeGameObject == true)
        {
            timer += Time.deltaTime;
            if (timer >= timeBeforeDeletion)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true)
        { if (canPickupCoin == true)
            {
                collision.GetComponent<PlayerState>().CoinPickup();
                spriteRenderer.sprite = null;
                animator.enabled = false;
                particles.Play();
                removeGameObject = true;
                canPickupCoin = false;
                audioSource.PlayOneShot(pickUpClip);
            }
           
        }

    }
}
