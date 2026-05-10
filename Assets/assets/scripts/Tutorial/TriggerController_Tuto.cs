using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class TriggerController_Tuto : MonoBehaviour
{
    [Header("Que quieres que pase?")]
    public UnityEvent Evento;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(esperaUnratico());    
        }
        
    }

    IEnumerator esperaUnratico()
    {
        yield return new WaitForSeconds(5f);
        Evento.Invoke();
        
    }
}
