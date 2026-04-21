using UnityEngine;

public class FallingCoin : MonoBehaviour
{
    Rigidbody2D rg;
    float speed = 1f;
    float direction;
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
        direction = randomSide(speed);
    }

    // Update is called once per frame
    void Update()
    {
        rg.linearVelocity = new Vector2(direction, 0);
    }

    float randomSide(float rSpeed)
    {
        int random = Random.Range(0, 2);
        float randomNum = Random.Range(0.5f, 1f);
        if (random == 0)
        {
            rSpeed = randomNum*-1;
        }
        else
        {
            rSpeed = randomNum*1;
        }
        return rSpeed;
    }
}
