using UnityEngine;
using UnityEngine.Animations;

public class Anim_Party : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Idle_Trigger()
    {
        anim.SetTrigger("Idle");
    }

    public void Expand_Trigger()
    {
        anim.SetTrigger("Expand");
    }
}
