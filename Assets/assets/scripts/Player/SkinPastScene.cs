using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinPastScene : MonoBehaviour
{
	public static SkinPastScene Instance { get; private set; }
	private const string Key = "SelectedCharacter";
	[SerializeField] private int currentSelection = 1;

	public int CurrentSelection => currentSelection;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
		currentSelection = Mathf.Clamp(PlayerPrefs.GetInt(Key, currentSelection), 1, 3);

		SceneManager.sceneLoaded += OnSceneLoaded;
		ApplyToActiveManager();
	}

	private void OnDestroy()
	{
		SceneManager.sceneLoaded -= OnSceneLoaded;
	}

	private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		ApplyToActiveManager();
	}

	public void SetSelection(int selectedIndex)
	{
		currentSelection = Mathf.Clamp(selectedIndex, 1, 3);
		PlayerPrefs.SetInt(Key, currentSelection);
		PlayerPrefs.Save();
		ApplyToActiveManager();
	}

	// Guarda la selección como un entero 1-based en PlayerPrefs y notifica al manager activo
	public void SaveSelection(int selectedIndex)
	{
		SetSelection(selectedIndex);
	}

	// Helper por si quieres guardar usando tres booleanos (por compatibilidad con tu UI actual).
	public void SaveSelectionByBools(bool character1, bool character2, bool character3)
	{
		if (character1) SetSelection(1);
		else if (character2) SetSelection(2);
		else if (character3) SetSelection(3);
	}

	private void ApplyToActiveManager()
	{
		var mgr = FindObjectOfType<SpriteChangerManager>();
		if (mgr != null)
		{
			mgr.SetSelection(currentSelection);
		}
	}
}
