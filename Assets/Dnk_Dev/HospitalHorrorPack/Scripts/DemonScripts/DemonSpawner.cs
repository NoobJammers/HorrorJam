using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpawner : MonoBehaviour
{   //new Vector3(-3.5f, 1.5f, -0.881f), new Vector3(-3.258f, 3.02f, 0f) 
    bool shouldSpawn = false;
    public GameObject demonCrawler;
    public Vector3[] demonSpawnPos;
    public void activate()
    {
        shouldSpawn = true;
        StartCoroutine(SpawnDemons());
    }

    IEnumerator SpawnDemons()
    {
        while (shouldSpawn)
        {
            int randomVal = Random.Range(0, demonSpawnPos.Length);
            Instantiate(demonCrawler,
                        demonSpawnPos[randomVal] + ((randomVal == 0 ? Vector3.up * Random.Range(0, 0.8f) : Vector3.forward * Random.Range(0, 0.6f)) * (Random.Range(0, 2) == 0 ? 1f : -1f)),
                        (randomVal == 0 ? Quaternion.Euler(90f, 0f, 0f) : Quaternion.Euler(180f, 0f, 0f)));

            yield return new WaitForSeconds(Random.Range(0.5f, 0.9f));

        }
    }
}
