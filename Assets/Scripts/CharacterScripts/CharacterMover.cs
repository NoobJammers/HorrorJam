using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System;
public class CharacterMover : MonoBehaviour
{
    private string animationToPlay = "Walking";
    private string animationOnceStopped = "standing";
    public float speed = 3;
    private NavMeshAgent agent;

    public Animator animator;
    public Action reachedDestination = () => { };
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        agent.speed = speed;
        if (!agent.isStopped)
        {
            if ((transform.position - agent.destination).magnitude < 0.2f)
            {
                StopMoving();
            }
        }
    }
    public Action GoToPoint(Vector3 startposition, Vector3 destination)
    {
        transform.position = startposition;
        transform.LookAt(destination);
        agent.isStopped = false;
        animator.Play(animationToPlay);
        agent.SetDestination(destination);
        return reachedDestination;

    }
    public void StopMoving()
    {
        reachedDestination.Invoke();
        animator.Play(animationOnceStopped);
        agent.isStopped = true;


    }
}
