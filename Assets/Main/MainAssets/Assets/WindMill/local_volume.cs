using System.Collections;
using UnityEngine;

public class ShowLightsInVolume : MonoBehaviour
{
    public Light[] lightsToShow;
    public float fadeDuration = 2f;

    private float[] targetIntensities;

    private void Start()
    {
        targetIntensities = new float[lightsToShow.Length];

        for (int i = 0; i < lightsToShow.Length; i++)
        {
            targetIntensities[i] = lightsToShow[i].intensity;
            lightsToShow[i].intensity = 0f;
            lightsToShow[i].enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < lightsToShow.Length; i++)
            {
                StartCoroutine(FadeLight(lightsToShow[i], targetIntensities[i]));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (Light light in lightsToShow)
            {
                StartCoroutine(FadeLight(light, 0f));
            }
        }
    }

    IEnumerator FadeLight(Light lightSource, float targetIntensity)
    {
        float startIntensity = lightSource.intensity;
        float time = 0f;

        while (time < fadeDuration)
        {
            lightSource.intensity = Mathf.Lerp(
                startIntensity,
                targetIntensity,
                time / fadeDuration
            );

            time += Time.deltaTime;
            yield return null;
        }

        lightSource.intensity = targetIntensity;
    }
}