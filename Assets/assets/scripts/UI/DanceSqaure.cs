using UnityEngine;
using UnityEngine.Events;

public class DanceSqaure : MonoBehaviour
{
    [SerializeField] private BarraBaile barraBaile;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] public GameObject BarraBaileObject;
    public UnityEvent onDanceComplete;
    [SerializeField] private float movementThreshold = 0.001f;

    Transform playerTransform;
    Vector3 lastPlayerPosition;
    
    private float countdownTimer = 15f;
    private bool isCountingDown = false;
    private const float COUNTDOWN_DURATION = 15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            playerTransform = collision.transform;
            lastPlayerPosition = playerTransform.position;

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
            playerTransform = null;
            lastPlayerPosition = Vector3.zero;
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
            bool isMoving = false;
            if (playerTransform != null)
            {
                float dx = Mathf.Abs(playerTransform.position.x - lastPlayerPosition.x);
                isMoving = dx > movementThreshold;
            }

            if (isMoving)
            {
                countdownTimer -= Time.deltaTime;
                if (countdownTimer <= 0f)
                {
                    countdownTimer = 0f;
                    StopCountdown();
                    onDanceComplete?.Invoke();
                }
            }

            // Actualizar la barra con el progreso (se mantiene cuando se pausa)
            if (barraBaile != null)
            {
                float progress = 1f - (countdownTimer / COUNTDOWN_DURATION); // 0 a 1
                barraBaile.UpdateBar(progress);
            }

            if (playerTransform != null)
                lastPlayerPosition = playerTransform.position;
        }
    }
}
