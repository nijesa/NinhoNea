using UnityEngine;
using UnityEngine.UI;

public class BallonsAlphaActive : MonoBehaviour
{
    [SerializeField] Image[] Ballons;

    public void ActivateBallons()
    {
        foreach (Image ballon in Ballons)
        {
            ballon.color = new Color(ballon.color.r, ballon.color.g, ballon.color.b, 1f);
        }
    }
}
