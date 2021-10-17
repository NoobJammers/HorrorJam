using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scene4Manager : MonoBehaviour
{

    static public Scene4Manager instance;
    [SerializeField] GameObject husband, wife, kid, demonCrawler;
    [SerializeField] DoorHandler kidsRoomDoor;
    [SerializeField] Transform enterRoomStartPoint;
    bool shouldSpawn = false;

    // 0 - Wall, 1 - Ceiling
    Vector3[] demonSpawnPos = { new Vector3(-3.5f, 1.5f, -0.881f), new Vector3(-3.258f, 3.02f, 0f) };
    private void Awake()
    {
        instance = this;
    }


    public void StartMirrorScene()
    {
        kidsRoomDoor.OpenDoor(2f);
        husband.transform.position = enterRoomStartPoint.position;
        husband.transform.DOMoveZ(transform.position.z - 3f, 4f);

    }


    public void StartCrawlScene()
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
