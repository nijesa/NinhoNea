using UnityEngine;
using UnityEngine.Events;

public class DanceSqaure : MonoBehaviour
{
    [SerializeField] private BarraBaile barraBaile;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] public GameObject BarraBaileObject;
    public UnityEvent onDanceComplete;

    Transform playerTransform;
    Vector3 lastPlayerPosition;
    
    private float countdownTimer = 1f;
    private bool isCountingDown = false;
    private const float COUNTDOWN_DURATION = 1f;
    [SerializeField] private float xMovementMargin = 1f;

    
    public UnityEvent onEnterDanceZone;
    public UnityEvent onExitDanceZone;
    
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(playerTag))
        {
            playerTransform = collision.transform;
            lastPlayerPosition = playerTransform.position;

            StartCountdown();
            BarraBaileObject.SetActive(true);
            onEnterDanceZone?.Invoke();
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
            onExitDanceZone?.Invoke();
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

                float currentX = playerTransform.position.x;
                float previousX = lastPlayerPosition.x;

                if(currentX==previousX)
                {
                    isMoving = false;
                }
                else
                {
                    isMoving = true;
                }
                
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
