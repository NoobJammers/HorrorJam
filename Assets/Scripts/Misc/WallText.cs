using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallText : MonoBehaviour
{
    [SerializeField] List<SpriteRenderer> murderList;

    bool shouldRepeat = true;
    float waitTime = 0.5f;



    public void DisplayBloodText()
    {
        StartCoroutine(DelayMe());
    }

    public void StopBloodText()
    {
        shouldRepeat = false;
        StartCoroutine(SmalDelay());
    }


    IEnumerator SmalDelay()
    {
        yield return new WaitForSeconds(2f);
        foreach (SpriteRenderer child in murderList)
        {
            child.gameObject.SetActive(false);
        }
    }

    IEnumerator DelayMe()
    {
        while (shouldRepeat)
        {
            foreach (SpriteRenderer child in murderList)
            {
                child.gameObject.SetActive(false);
                child.DOFade(1f, 0f);
                child.transform.localPosition = new Vector3(
                    // Random.Range(0.796f, 2.18f),
                    Random.Range(0f, 3f),
                    Random.Range(1.35f, 2.8f),
                    -0.03f
                );
                child.transform.localRotation = Quaternion.Euler(Vector3.zero);
                child.transform.localRotation = Quaternion.Euler(
                    0f,
                    0f,
                    child.transform.localRotation.eulerAngles.z + (Random.Range(0f, 30f) * (Random.Range(0, 2) == 0 ? 1f : -1f))
                );
                child.gameObject.SetActive(true);
                // child.DOFade(0f, 10f);
                float newWaitTime = waitTime + (Random.Range(0, 0.7f) * (Random.Range(0, 2) == 0 ? 1f : -1f));
                newWaitTime = newWaitTime < 0f ? 0f : newWaitTime;
                yield return new WaitForSeconds(newWaitTime);

            }
            waitTime /= 3f;
        }
    }
}