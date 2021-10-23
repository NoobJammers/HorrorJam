using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DemonCrawler : MonoBehaviour
{
    public Animator animator;

    public Transform endpos;
    public float starttime;
    public float speed = 3;
    private void Start()
    {
        animator.SetTrigger("Crawl");


    }

    private void Update()
    {
        while (Time.time - starttime < 10)
        {
            transform.position += Time.deltaTime * speed * transform.forward;
        }
    }




}
