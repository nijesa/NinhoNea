using UnityEngine;
using UnityEngine.Animations;

public class Emotion_Animation : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void expand()
    {
        anim.SetTrigger("Expand");
    }

    public void stop()
    {
        anim.SetTrigger("Stop");
    }
}
