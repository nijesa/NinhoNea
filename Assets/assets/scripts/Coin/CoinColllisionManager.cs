using System;
using UnityEngine;


public class CoinColllisionManager : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Console.Write("Coin collected!");
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Cosito")|| collision.gameObject.CompareTag("CositoMal"))
        {
            return;

        }
        else
        {
            Console.Write("Toca madera");
            Destroy(gameObject);
        }
    }
}
