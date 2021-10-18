using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;
public class CharacterMover : MonoBehaviour
{
    private string animationToPlay = "Walking";
    private string animationOnceStopped = "standing";
    public float speed = 3;
    private NavMeshAgent agent;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    private void Update()
    {
        agent.speed = speed;
        if (agent.enabled)
        {
            if ((transform.position - agent.destination).magnitude < 0.2f)
            {
                agent.isStopped = true;
                agent.enabled = false;
                animator.Play(animationOnceStopped);
            }
        }
    }
    public void GoToPoint(Vector3 startposition, Vector3 destination)
    {
        transform.position = startposition;
        transform.LookAt(destination);
        agent.enabled = true;
        animator.Play(animationToPlay);
        agent.SetDestination(destination);


    }
    public void StopMoving()
    {
        animator.Play(animationOnceStopped);
        agent.isStopped = true;
        agent.enabled = false;

    }
}
