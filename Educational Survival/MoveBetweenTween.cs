using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenTween : MonoBehaviour
{
    private IEnumerator moveToPoint;
    private bool goingBack = false;

    [Tooltip("Defines velocity of moving object")]
    [SerializeField] float speed;
    [Tooltip("Object start movement from these coordinates")]
    [SerializeField] Vector2 startPoint;
    [Tooltip("Object moves towards these coordinates")]
    [SerializeField] Vector2 targetPoint;
    void OnEnable()
    {
        moveToPoint = MoveToPoint();
        StartCoroutine(moveToPoint);
    }
    private IEnumerator MoveToPoint()
    {
        transform.localPosition = startPoint;
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
        if (goingBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, startPoint,
                speed * Time.deltaTime);
        } else
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint,
                speed * Time.deltaTime);
        }
    }
    private void ManagePosition()
    {
        if (Vector2.Distance(transform.position, targetPoint) < 0.1f && goingBack == false)
        {
            goingBack = !goingBack;
        }
        else if (Vector2.Distance(transform.position, startPoint) < 0.1f && goingBack == true)
        {
            goingBack = !goingBack;
        }
    }
}
