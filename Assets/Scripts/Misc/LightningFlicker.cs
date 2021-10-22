using UnityEngine;
using System.Collections;

public class LightningFlicker : MonoBehaviour
{



    public float frequency = 1.5f; // cycle frequency per second
    public int oscillations = 10;
    public float max_intensity;
    public float min_intensity;
    // Store the original color

    public float original_intensity;
    public Light light;
    private Coroutine flickr;
    public void startflickering()
    {
        if (!light)
            light = GetComponent<Light>();
        original_intensity = light.intensity;
        flickr = StartCoroutine(Flickr());
    }

    IEnumerator Flickr()
    {
        while (true)
        {
            int oscillation_count = oscillations;
            bool intensityMax = true;
            while (oscillation_count > 0)
            {
                if (intensityMax)
                {
                    light.intensity = max_intensity;
                    intensityMax = false;
                }
                else
                {
                    light.intensity = min_intensity;
                    intensityMax = true;
                }
                yield return new WaitForSeconds(0.05f);
                oscillation_count--;
            }
            light.intensity = 0;
            yield return new WaitForSecondsRealtime(frequency);
        }
    }

    public void stopflickering()
    {
        StopCoroutine(flickr);
    }





}