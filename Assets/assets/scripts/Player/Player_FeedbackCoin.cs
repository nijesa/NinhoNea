using System.Collections;
using UnityEngine;

public class Player_FeedbackCoin : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    Color alfa_Zero = new Color(1f, 1f, 1f, 0f);
    Color alfa_One = new Color(1f, 1f, 1f, 1f);
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void alphaChange()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        float elapsedTime = 0f;
        float blinkDuration = 3f;
        float blinkSpeed = 5f; // Controls how fast the blinking occurs

        while (elapsedTime < blinkDuration)
        {
            // Toggle between visible and invisible
            float alpha = Mathf.PingPong(elapsedTime * blinkSpeed, 1f);
            spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // Ensure sprite is fully visible after blinking
        spriteRenderer.color = alfa_One;
    }

}
