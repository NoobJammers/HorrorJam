using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DemonCrawler : MonoBehaviour
{
    [SerializeField] Animator animator;


    private void Start()
    {
        animator.SetTrigger("Crawl");
        transform.DOMoveX(transform.localPosition.x - 20f, 4f).SetEase(Ease.Linear).OnComplete(() => Destroy(gameObject));
    }



}
