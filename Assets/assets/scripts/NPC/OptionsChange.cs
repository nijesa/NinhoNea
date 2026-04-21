using UnityEngine;
using DG.Tweening;
public class OptionsChange : MonoBehaviour
{
    public RectTransform[] RT_paneles;
    [SerializeField] float moveDistance = -500f;

   public void MoverPaneles()
    {
        for (int i = 0; i < RT_paneles.Length; i++)
        {
            RT_paneles[i].DOMoveX((RT_paneles[i].anchoredPosition.x + moveDistance), 1f).SetEase(Ease.InOutSine);
        }
    }
}
