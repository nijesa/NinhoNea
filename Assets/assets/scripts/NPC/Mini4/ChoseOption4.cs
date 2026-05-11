using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ChoseOption4 : MonoBehaviour
{
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private float timeInsideToTrigger = 5f;
    [SerializeField] private UnityEvent onPlayerStayedInside;

    private Coroutine triggerRoutine;
    private bool eventTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag) || eventTriggered)
        {
            return;
        }

        if (triggerRoutine != null)
        {
            StopCoroutine(triggerRoutine);
        }

        triggerRoutine = StartCoroutine(TriggerAfterDelay());
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag))
        {
            return;
        }

        if (triggerRoutine != null)
        {
            StopCoroutine(triggerRoutine);
            triggerRoutine = null;
        }

        eventTriggered = false;
    }

    private IEnumerator TriggerAfterDelay()
    {
        yield return new WaitForSeconds(timeInsideToTrigger);

        triggerRoutine = null;
        eventTriggered = true;
        onPlayerStayedInside?.Invoke();
    }
}
