using UnityEngine;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class Movement : MonoBehaviour
{
	[Header("Objeto a mover")]
	public Transform targetObject;

	[Header("Valor recibido")]
	[SerializeField] private float receivedValue;
    [SerializeField] private bool debugLogs;

    [Header("Relative position limits")]
    [SerializeField] public float minX;
    [SerializeField] public float maxX;

	private readonly object locker = new object();
	private volatile bool hasNewValue;
	private static readonly Regex NumberRegex = new Regex(@"-?\d+(?:[\.,]\d+)?", RegexOptions.Compiled);

	private void OnEnable()
	{
		if (targetObject == null)
		{
			Debug.LogWarning("Movement: no asignaste targetObject en el Inspector.");
		}

		Application.logMessageReceivedThreaded += HandleLogMessage;
	}

	private void OnDisable()
	{
		Application.logMessageReceivedThreaded -= HandleLogMessage;
	}

	private void Update()
	{
		if (!hasNewValue || targetObject == null)
		{
			return;
		}

		lock (locker)
		{
			// Mapea el rango de entrada esperado (3..643) al rango de posición (minX..maxX)
			float t = Mathf.InverseLerp(3f, 643f, receivedValue);
			float nuevaPos = Mathf.Lerp(minX, maxX, t);
			Vector3 position = targetObject.position;
			position.x = nuevaPos;
			targetObject.position = position;
			hasNewValue = false;

			if (debugLogs)
			{
				Debug.Log("Movement: aplicado X = " + nuevaPos + " (entrada=" + receivedValue + ")");
			}
		}
	}

	private void HandleLogMessage(string message, string stackTrace, LogType type)
	{
		if (string.IsNullOrWhiteSpace(message))
		{
			return;
		}

		// Ignora logs del propio script para evitar bucle de realimentación.
		if (message.StartsWith("Movement:", StringComparison.Ordinal))
		{
			return;
		}

		Match match = NumberRegex.Match(message);
		if (!match.Success)
		{
			return;
		}

		string numberText = match.Value.Replace(',', '.');
		if (!float.TryParse(numberText, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
		{
		return;
		}

		lock (locker)
		{
			receivedValue = value;
			hasNewValue = true;
		}

		if (debugLogs)
		{
			Debug.Log("Movement: número recibido desde log = " + value + " | texto: " + message);
		}
	}

	private void OnApplicationQuit()
	{
		Application.logMessageReceivedThreaded -= HandleLogMessage;
	}
}
