using UnityEngine;
using TMPro;

public class Player_Points : MonoBehaviour
{
    [SerializeField] TMP_Text pointsText;
    int points = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pointsText.text = "Points: " + points;
    }

    void addPoints(int amount)
    {
        points += amount;
        pointsText.text = "Points: " + points;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Cosito"))
        {
            addPoints(1);
        }else if (collision.gameObject.CompareTag("CositoMal"))
        {
            addPoints(-1);
        }
    }
}
