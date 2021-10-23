using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DemonCrawler : MonoBehaviour
{
    public Animator animator;

    public Transform direction;
    public float starttime;
    public float speed = 3;
    private void Start()
    {
        animator.SetTrigger("Crawl");
        starttime = Time.time;

    }

    private void Update()
    {
        if (Time.time - starttime < 20)
        {
            transform.position += Time.deltaTime * speed * direction.forward;
        }
        else
        {
            Destroy(gameObject);
        }
    }




}
