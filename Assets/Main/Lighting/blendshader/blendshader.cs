using UnityEngine;
using UnityEngine.Rendering;

public class VolumeBlendTrigger : MonoBehaviour
{
    public Volume targetVolume;
    public float blendSpeed = 1f;

    private float targetWeight = 0f;

    private void Start()
    {
        targetVolume.weight = 0f;
    }

    private void Update()
    {
        targetVolume.weight = Mathf.Lerp(
            targetVolume.weight,
            targetWeight,
            blendSpeed * Time.deltaTime
        );
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            targetWeight = 1f;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            targetWeight = 0f;
    }
}