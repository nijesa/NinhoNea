using UnityEngine;
using UnityEngine.Events;

public class DanceSqaure : MonoBehaviour
{
    [SerializeField] private BarraBaile barraBaile;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] public GameObject BarraBaileObject;
    public UnityEvent onDanceComplete;
    
    private float countdownTimer = 30f;
    private bool isCountingDown = false;
    private const float COUNTDOWN_DURATION = 30f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            StartCountdown();
            BarraBaileObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            StopCountdown();
            BarraBaileObject.SetActive(false);
        }
    }

    private void StartCountdown()
    {
        if (!isCountingDown)
        {
            isCountingDown = true;
            countdownTimer = COUNTDOWN_DURATION;
            
            // Activar la barra
            if (barraBaile != null)
            {
                barraBaile.ActivateBar();
            }
        }
    }

    private void StopCountdown()
    {
        if (isCountingDown)
        {
            isCountingDown = false;
            countdownTimer = COUNTDOWN_DURATION;
            
            // Desactivar la barra y reiniciar
            if (barraBaile != null)
            {
                barraBaile.DeactivateBar();
            }
        }
    }

    private void Update()
    {
        if (isCountingDown)
        {
            countdownTimer -= Time.deltaTime;
            
            if (countdownTimer <= 0f)
            {
                countdownTimer = 0f;
                StopCountdown();
                onDanceComplete?.Invoke();
            }
            
            // Actualizar la barra con el progreso
            if (barraBaile != null)
            {
                float progress = 1f - (countdownTimer / COUNTDOWN_DURATION); // 0 a 1
                barraBaile.UpdateBar(progress);
            }
        }
    }
}
