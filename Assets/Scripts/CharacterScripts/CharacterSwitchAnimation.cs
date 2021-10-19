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
    public void switchtoanimation(string animname, int delay)
    {
        StartCoroutine(StartAnimWithDelay(animname, delay));
    }
    IEnumerator StartAnimWithDelay(string animname, int delay)
    {
        yield return new WaitForSeconds(delay);
        animator.Play(animname);
    }
}
