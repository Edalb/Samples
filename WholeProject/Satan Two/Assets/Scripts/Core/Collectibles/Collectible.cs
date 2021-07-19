using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private Collider2D itemCollider;
    private SpriteRenderer spriteRenderer;
    [SerializeField] AudioFeedback audioFeedback;
    [SerializeField] GameObject collectionParticles;
    protected GameManager gameManager;
    private bool wasCollected = false;
    private void Start()
    {
        itemCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Horn")
        {
            if (collision.GetComponent<Horn>().IsPlayerHorn())
            {
                CollectItem();
            }
        }
        if (collision.tag == "Player")
        {
            CollectItem();
        }
    }
    private void CollectItem()
    {
        if(wasCollected == false)
        {
            wasCollected = true;
            itemCollider.enabled = false;
            if(audioFeedback != null)
            {
                audioFeedback.PlayAudio();
            }
            if(collectionParticles != null)
            {
                Instantiate(collectionParticles, transform.position, Quaternion.identity);
            }
            spriteRenderer.color = new Color(1, 1, 1, 0);
            Invoke("ManageRewards", 0.1f);
            Invoke("AutoDestroy", 0.11f);
        }
    }
    protected virtual void ManageRewards()
    {
    }
    public void LoadGameManager(GameManager manager)
    {
        gameManager = manager;
    }
    private void AutoDestroy()
    {
        Destroy(this.gameObject);
    }
}
