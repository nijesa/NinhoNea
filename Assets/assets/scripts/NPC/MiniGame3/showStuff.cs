using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showStuff : MonoBehaviour
{
    [SerializeField] Image[] thingToShow;
    [SerializeField] GameObject thingToShow_Parent;
    [SerializeField] float fadeDuration = 1f;

    Image[] targetImages;
    Coroutine fadeLoopCoroutine;

    void Awake()
    {
        if (thingToShow != null && thingToShow.Length > 0)
        {
            targetImages = thingToShow;
        }
        else if (thingToShow_Parent != null)
        {
            targetImages = thingToShow_Parent.GetComponentsInChildren<Image>(true);
        }
        else
        {
            targetImages = GetComponentsInChildren<Image>(true);
        }
    }

    public void StartAlphaLoop()
    {
        if (fadeLoopCoroutine == null)
        {
            fadeLoopCoroutine = StartCoroutine(FadeLoop());
        }
    }

    public void StopAlphaLoop()
    {
        if (fadeLoopCoroutine != null)
        {
            StopCoroutine(fadeLoopCoroutine);
            fadeLoopCoroutine = null;
        }

        SetAlphaForAll(0f);
    }

    IEnumerator FadeLoop()
    {
        while (true)
        {
            float elapsed = 0f;

            while (elapsed < fadeDuration)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, elapsed / Mathf.Max(fadeDuration, 0.0001f));
                SetAlphaForAll(alpha);
                yield return null;
            }

            SetAlphaForAll(0f);
            yield return null;
        }
    }

    void SetAlphaForAll(float alpha)
    {
        if (targetImages == null)
        {
            return;
        }

        for (int i = 0; i < targetImages.Length; i++)
        {
            if (targetImages[i] == null)
            {
                continue;
            }

            Color color = targetImages[i].color;
            color.a = alpha;
            targetImages[i].color = color;
        }
    }
}
