using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownside : MonoBehaviour
{
    private IEnumerator moveToPoint;

    [SerializeField] float speed;
    [SerializeField] float positionY;
    private Vector2 targetPoint;
    void Start()
    {
        targetPoint = new Vector2(this.transform.position.x, positionY);
        moveToPoint = MoveToPoint();
        StartCoroutine(moveToPoint);
    }
    private IEnumerator MoveToPoint()
    {
        WaitForSeconds wait = new WaitForSeconds(0.01f);
        while (true)
        {
            yield return wait;
            ManageMovement();
            ManagePosition();
        }
    }
    private void ManageMovement()
    {
        this.transform.position = Vector2.MoveTowards(this.transform.position, targetPoint,
            speed * Time.deltaTime);
    }
    private void ManagePosition()
    {
        if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
        {
            StopAllCoroutines();
            if (GetComponent<Enemy>() == true)
            {
                GetComponent<Enemy>().Death();
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
    public void SetSpeed(float newValue)
    {
        speed = newValue;
    }
}
