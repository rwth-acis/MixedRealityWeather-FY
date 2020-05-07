using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    [SerializeField] private Transform lightningClippingPlane;
    [SerializeField] private float startHeight = 0;
    [SerializeField] private float endHeight = -0.3f;

    private float nextLightningCountdown;

    private bool lightningAnimInProgress;

    public bool LightningActive
    {
        get; set;
    }

    private void Awake()
    {
        LightningActive = true;
    }

    private void Update()
    {
        if (LightningActive && !lightningAnimInProgress)
        {
            nextLightningCountdown -= Time.deltaTime;
            if (nextLightningCountdown <= 0f)
            {
                StartCoroutine(LightningCombination());
            }
        }
    }

    private IEnumerator LightningCombination()
    {
        lightningAnimInProgress = true;
        float strikeDuration = Random.Range(0.05f, 0.1f);
        float strikeIdleTime = Random.Range(0.05f, 0.25f);
        float gap = Random.Range(0.02f, 0.2f);
        yield return StrikeLightning(strikeDuration, strikeIdleTime);
        int minorStrikes = Random.Range(0, 4);
        if (minorStrikes > 0)
        {
            yield return new WaitForSeconds(gap);
            for (int i = 0; i < minorStrikes; i++)
            {
                strikeDuration = Random.Range(0.05f, 0.1f);
                strikeIdleTime = Random.Range(0.05f, 0.15f);
                gap = Random.Range(0.05f, 0.2f);
                yield return StrikeLightning(strikeDuration, strikeIdleTime);
                if (i < minorStrikes - 1)
                {
                    yield return new WaitForSeconds(gap);
                }
            }
        }
        nextLightningCountdown = Random.Range(1f, 5f);
        lightningAnimInProgress = false;
    }

    private IEnumerator StrikeLightning(float duration, float idleTime)
    {
        Vector3 start = lightningClippingPlane.localPosition;
        start.y = startHeight;
        Vector3 end = lightningClippingPlane.localPosition;
        end.y = endHeight;

        yield return Move(lightningClippingPlane, start, end, duration / 2f);
        yield return new WaitForSeconds(idleTime);
        yield return Move(lightningClippingPlane, end, start, duration / 2f);
    }

    private IEnumerator Move(Transform target, Vector3 start, Vector3 end, float duration)
    {
        float time = 0;
        while (time < duration)
        {
            target.localPosition = Vector3.Lerp(start, end, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        target.localPosition = end;
    }
}
