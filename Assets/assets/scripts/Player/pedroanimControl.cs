using UnityEngine;

public class pedroanimControl : MonoBehaviour
{
    [SerializeField] private Animator pedroAnimator;
    

    public void TriggerAnimation(string triggerName)
    {
        if (pedroAnimator != null)
        {
            pedroAnimator.SetTrigger(triggerName);
        }
    }
}
