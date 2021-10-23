using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpawner : MonoBehaviour
{   //new Vector3(-3.5f, 1.5f, -0.881f), new Vector3(-3.258f, 3.02f, 0f) 
    bool shouldSpawn = false;
    public GameObject demonCrawler;

    public void activate()
    {
        shouldSpawn = true;
        StartCoroutine(SpawnDemons());
    }

    IEnumerator SpawnDemons()
    {
        while (shouldSpawn)
        {

            GameObject crawler = Instantiate(demonCrawler, transform.position, Quaternion.identity);

            GameObject crawler_body = crawler.transform.Find("demon_body").gameObject;

            crawler_body.transform.up = transform.up;
            crawler_body.transform.forward = transform.forward;
            crawler_body.transform.right = transform.right;
            yield return new WaitForSeconds(Random.Range(4, 6));

        }
    }
}
