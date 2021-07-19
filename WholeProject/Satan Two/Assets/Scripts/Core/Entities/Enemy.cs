using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int hornsActive = 0;
    private Horn[] horns;
    protected SpriteRenderer spriteRenderer;
    protected Animator animator;
    protected GameManager gameManager;
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        horns = GetComponentsInChildren<Horn>();
    }
    public int ReturnHornsActive()
    {
        return hornsActive;
    }
    public void HornEntersCollision()
    {
        hornsActive++;
        if(hornsActive == 2)
        {
            Match();
        }
    }
    public void HornLeavesCollision()
    {
        hornsActive--;
    }
    public void LoadSkin(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }
    protected virtual void Match()
    {
        animator.SetTrigger("Match");
        Invoke("Death", 0.00001f);
    }
    public virtual void Death()
    {
        foreach(Horn horn in horns)
        {
            horn.HideHorns();
        }
        GetComponent<MoveDownside>().StopAllCoroutines();
        Invoke("DestroyMe", 1.5f);
    }
    private void DestroyMe()
    {
        Destroy(this.gameObject);
        gameManager.RespawnEnemy();
    }
    public void LoadGameManager(GameManager manager)
    {
        gameManager = manager;
    }
}
