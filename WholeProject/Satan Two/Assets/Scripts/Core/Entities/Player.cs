using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Enemy
{
    [SerializeField] AudioFeedback[] scoreFeedbacks;
    [SerializeField] AudioFeedback playerDeathFeedback;
    [SerializeField] GameObject deathParticles;
    
    private bool isDead = false;
    protected override void Match()
    {
        animator.SetTrigger("Match");
        gameManager.ScorePoint();
        gameManager.gameData.satanTwos++;
        int selectScore = Random.Range(0, scoreFeedbacks.Length);
        scoreFeedbacks[selectScore].PlayAudio();
    }
    public override void Death()
    {
        if(isDead == false)
        {
            gameManager.LoseLife();
            isDead = true;
            playerDeathFeedback.PlayAudio();
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            spriteRenderer.color = new Color(1, 1, 1, 0.5f);
            Invoke("Respawn", 5f);
        }
    }
    private void Respawn()
    {
        isDead = false;
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
