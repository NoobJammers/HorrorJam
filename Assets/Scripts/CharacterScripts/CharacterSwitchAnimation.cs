using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitchAnimation : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void switchtoanimation(string animname, int delay, int speed)
    {
        StartCoroutine(StartAnimWithDelay(animname, delay, speed));
    }
    IEnumerator StartAnimWithDelay(string animname, int delay, int speed)
    {
        yield return new WaitForSeconds(delay);
        animator.Play(animname);
        animator.speed = speed;
    }
}
