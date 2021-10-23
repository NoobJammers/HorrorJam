using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SaveMyBabyText : MonoBehaviour
{
    public bool displaySaveMyBabyText = false;
    public List<SpriteRenderer> saveMyBabyList;


    bool shouldRepeat = true;
    float waitTime = 0.5f;

    public void DisplaySaveText()
    {
        StartCoroutine(DelayMe());
    }

    public void StopSaveText()
    {
        shouldRepeat = false;
        StartCoroutine(SmalDelay());

        foreach (SpriteRenderer child in saveMyBabyList)
        {
            child.DOFade(0f, 0f);

        }

    }


    IEnumerator SmalDelay()
    {
        yield return new WaitForSeconds(2f);
        foreach (SpriteRenderer child in saveMyBabyList)
        {
            child.gameObject.SetActive(false);
        }
    }

    IEnumerator DelayMe()
    {
        while (shouldRepeat)
        {
            foreach (SpriteRenderer child in saveMyBabyList)
            {
                child.gameObject.SetActive(false);
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
            if (waitTime > 0.05f)
            {
                waitTime /= 3f;
            }
        }
    }


}