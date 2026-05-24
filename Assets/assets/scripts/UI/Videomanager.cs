using UnityEngine;
using UnityEngine.Video;

public class Videomanager : MonoBehaviour
{
	[SerializeField] private VideoPlayer videoPlayer;
	[SerializeField] private GameObject[] objectToDisable;
	[SerializeField] private GameObject[] objectToEnable;

	private void OnEnable()
	{
		if (videoPlayer != null)
		{
			videoPlayer.loopPointReached += OnVideoFinished;
		}
	}

	private void OnDisable()
	{
		if (videoPlayer != null)
		{
			videoPlayer.loopPointReached -= OnVideoFinished;
		}
	}

	private void OnVideoFinished(VideoPlayer source)
	{
		if (objectToDisable != null)
		{
			for (int i = 0; i < objectToDisable.Length; i++)
			{
				objectToDisable[i].SetActive(false);
			}
		}

		if (objectToEnable != null)
		{
			for (int i = 0; i < objectToEnable.Length; i++)
			{
				objectToEnable[i].SetActive(true);
			}
		}
	}
}
