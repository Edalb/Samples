using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horn : MonoBehaviour
{
    private BoxCollider2D hornCollider;
    private Enemy hornOwner;
    void Start()
    {
        hornOwner = GetComponentInParent<Enemy>();
        hornCollider = GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Horn")
        {
            hornOwner.HornEntersCollision();
        }
        if(collision.tag == "Player")
        {
            if(hornOwner.ReturnHornsActive() < 2)
            {
                collision.GetComponent<Player>().Death();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Horn")
        {
            hornOwner.HornLeavesCollision();
        }
    }
    public void HideHorns()
    {
        hornCollider.enabled = false;
    }
    public bool IsPlayerHorn()
    {
        if (hornOwner.GetComponentInParent<Player>())
        {
            return true;
        } else
        {
            return false;
        }
    }
}
