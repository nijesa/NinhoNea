using UnityEngine;

public class PlayerColllisionManager : MonoBehaviour
{
    [SerializeField] Player_FeedbackCoin feedbackCoin;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CositoMal"))
        {
            feedbackCoin.alphaChange();
        }
    }
}
