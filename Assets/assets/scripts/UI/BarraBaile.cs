using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BarraBaile : MonoBehaviour
{
    [SerializeField] private Image barraImage;
    private UnityEvent onBarFilled;
        public void ActivateBar()
    {
        if (barraImage != null)
        {
            barraImage.gameObject.SetActive(true);
            barraImage.fillAmount = 0f;
        }
    }

    public void DeactivateBar()
    {
        if (barraImage != null)
        {
            gameObject.SetActive(false);
            barraImage.fillAmount = 0f;
        }
    }

    public void UpdateBar(float progress)
    {
        if (barraImage != null)
        {
            // progress va de 0 a 1
            barraImage.fillAmount = Mathf.Clamp01(progress);
        }
    }
}
