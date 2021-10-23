using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitchAnimation : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void switchtoanimation(string animname, int delay, float speed)
    {
        StartCoroutine(StartAnimWithDelay(animname, delay, speed));
    }
    IEnumerator StartAnimWithDelay(string animname, int delay, float speed)
    {
        yield return new WaitForSeconds(delay);
        animator.Play(animname);
        animator.speed = speed;
    }
}
