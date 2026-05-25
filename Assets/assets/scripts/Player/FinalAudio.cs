using UnityEngine;

public class FinalAudio : MonoBehaviour
{
    [SerializeField] private AudioSource finalAudioSource;
    private bool waitingForEnd;

    private void Start()
    {
        if (finalAudioSource == null)
        {
            finalAudioSource = GetComponent<AudioSource>();
        }

        if (finalAudioSource == null || finalAudioSource.clip == null)
        {
            Debug.LogWarning("FinalAudio: No hay un AudioSource con clip asignado.");
            return;
        }

        finalAudioSource.Play();
        waitingForEnd = true;
    }

    private void Update()
    {
        if (!waitingForEnd)
        {
            return;
        }

        if (!finalAudioSource.isPlaying)
        {
            waitingForEnd = false;
            CloseApplication();
        }
    }

    private static void CloseApplication()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
