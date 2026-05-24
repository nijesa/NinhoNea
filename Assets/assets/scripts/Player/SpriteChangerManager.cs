using UnityEngine;

public class SpriteChangerManager : MonoBehaviour
{
    [Header("Seleccion (1-based)")]
    [SerializeField] public int Character_Num = 1;

    [Header("Personajes")]
    [SerializeField] private GameObject[] characters;

    private void Awake()
    {
        // Leer la selección guardada (si existe) antes de aplicar
        if (PlayerPrefs.HasKey("SelectedCharacter"))
        {
            Character_Num = PlayerPrefs.GetInt("SelectedCharacter", Character_Num);
        }
    }

    private void Start()
    {
        ApplySelection();
    }

    private void ApplySelection()
    {
        if (characters == null || characters.Length == 0)
            return;

        int index = Mathf.Clamp(Character_Num - 1, 0, characters.Length - 1);
        for (int i = 0; i < characters.Length; i++)
        {
            if (characters[i] != null)
                characters[i].SetActive(i == index);
        }
    }

    public void ChoseCharacter()
    {
        ApplySelection();
    }

    // Permite que otras clases (ej. SkinPastScene) establezcan la selección y la apliquen
    public void SetSelection(int selected)
    {
        if (characters == null || characters.Length == 0)
            return;

        Character_Num = Mathf.Clamp(selected, 1, characters.Length);
        ApplySelection();

        if (SkinPastScene.Instance != null)
        {
            SkinPastScene.Instance.SetSelection(Character_Num);
        }
    }

    public void AddNumber()
    {
        if (characters == null || characters.Length == 0)
            return;

        Character_Num = (Character_Num % characters.Length) + 1;
        ApplySelection();

        if (SkinPastScene.Instance != null)
        {
            SkinPastScene.Instance.SetSelection(Character_Num);
        }
    }

    public void SubtractNumber()
    {
        if (characters == null || characters.Length == 0)
            return;

        Character_Num = ((Character_Num - 2 + characters.Length) % characters.Length) + 1;
        ApplySelection();

        if (SkinPastScene.Instance != null)
        {
            SkinPastScene.Instance.SetSelection(Character_Num);
        }
    }
}
