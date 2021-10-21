using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
using System;
public class CharacterMover : MonoBehaviour
{
    private string animationToPlay = "Walking";

    public float speed = 3;
    private NavMeshAgent agent;

    public Animator animator;
    public Action reachedDestination = () => { };
    // Start is called before the first frame update
    void Start()
    {
        gameObject.TryGetComponent<NavMeshAgent>(out agent);



    }

    private void Update()
    {
        if (agent)
        {
            agent.speed = speed;
            if (agent.isOnNavMesh && !agent.isStopped)
            {
                if ((transform.position - agent.destination).magnitude < 0.2f)
                {
                    StopMoving();
                }
            }
        }
    }
    public void GoToPoint(Vector3 startposition, Vector3 destination, float animspeed = 1)
    {
        transform.position = startposition;
        transform.LookAt(destination);
        agent.isStopped = false;
        animator.Play(animationToPlay);
        animator.speed = animspeed;
        agent.SetDestination(destination);

    }
    /*    public Action GoToPointNoNavmesh(Vector3 startposition, Vector3 destination, float time)
        {

        }*/
    public void StopMoving()
    {
        reachedDestination.Invoke();
        animator.speed = 1;
        agent.isStopped = true;


    }
}
