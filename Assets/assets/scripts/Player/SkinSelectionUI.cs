using UnityEngine;

// Ejemplo simple de cómo exponer métodos para los botones de la UI
public class SkinSelectionUI : MonoBehaviour
{
    // Llamar desde un botón con parámetro (ej: Button OnClick -> SelectByIndex(1))
    public void SelectByIndex(int index)
    {
        if (SkinPastScene.Instance != null)
            SkinPastScene.Instance.SaveSelection(index);
    }

    // Avanza y guarda la nueva selección (usa el manager si está presente)
    public void SelectNext()
    {
        var mgr = FindObjectOfType<SpriteChangerManager>();
        if (mgr != null)
        {
            mgr.AddNumber();
            if (SkinPastScene.Instance != null)
                SkinPastScene.Instance.SaveSelection(mgr.Character_Num);
        }
        else if (SkinPastScene.Instance != null)
        {
            int cur = PlayerPrefs.GetInt("SelectedCharacter", 1);
            int next = cur == 3 ? 1 : cur + 1;
            SkinPastScene.Instance.SaveSelection(next);
        }
    }

    public void SelectPrev()
    {
        var mgr = FindObjectOfType<SpriteChangerManager>();
        if (mgr != null)
        {
            mgr.SubtractNumber();
            if (SkinPastScene.Instance != null)
                SkinPastScene.Instance.SaveSelection(mgr.Character_Num);
        }
        else if (SkinPastScene.Instance != null)
        {
            int cur = PlayerPrefs.GetInt("SelectedCharacter", 1);
            int prev = cur == 1 ? 3 : cur - 1;
            SkinPastScene.Instance.SaveSelection(prev);
        }
    }
}
