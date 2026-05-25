using UnityEngine;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class ArmsMovement : MonoBehaviour
{
	[Header("Hueso a rotar")]
	[SerializeField] private Transform bone;

	[Header("Brazo seleccionado")]
	[SerializeField] private bool useLeftArm = true;

	[Header("Valor recibido")]
	[SerializeField] private float receivedAngle;
	[SerializeField] private bool debugLogs;

	[Header("Ajuste de rotación")]
	[SerializeField] private float angleOffset;

	private readonly object locker = new object();
	private volatile bool hasNewAngle;

	private static readonly Regex LeftArmRegex = new Regex(
		"\"brazoIzq\"\\s*:\\s*(-?\\d+(?:[\\.,]\\d+)?)",
		RegexOptions.Compiled);

	private static readonly Regex RightArmRegex = new Regex(
		"\"brazoDer\"\\s*:\\s*(-?\\d+(?:[\\.,]\\d+)?)",
		RegexOptions.Compiled);

	private void OnEnable()
	{
		if (bone == null)
		{
			Debug.LogWarning("ArmsMovement: no asignaste el hueso en el Inspector.");
		}

		Application.logMessageReceivedThreaded += HandleLogMessage;
	}

	private void OnDisable()
	{
		Application.logMessageReceivedThreaded -= HandleLogMessage;
	}

	private void Update()
	{
		if (!hasNewAngle || bone == null)
		{
			return;
		}

		lock (locker)
		{
            float finalAngle;
            if (useLeftArm==false){
                finalAngle = (receivedAngle + angleOffset) * -1f;
            }
			else{
				finalAngle = (receivedAngle + angleOffset) * 1f;
			}
			bone.localRotation = Quaternion.Euler(0f, 0f, finalAngle);
			hasNewAngle = false;

			if (debugLogs)
			{
				string armName = useLeftArm ? "izquierdo" : "derecho";
				Debug.Log("ArmsMovement: aplicado ángulo " + finalAngle + " al brazo " + armName);
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
		if (message.StartsWith("ArmsMovement:", StringComparison.Ordinal))
		{
			return;
		}

		Regex selectedRegex = useLeftArm ? LeftArmRegex : RightArmRegex;
		Match match = selectedRegex.Match(message);
		if (!match.Success)
		{
			return;
		}

		string numberText = match.Groups[1].Value.Replace(',', '.');
		if (!float.TryParse(numberText, NumberStyles.Float, CultureInfo.InvariantCulture, out float angleValue))
		{
			return;
		}

		lock (locker)
		{
			receivedAngle = angleValue;
			hasNewAngle = true;
		}

		if (debugLogs)
		{
			Debug.Log("ArmsMovement: ángulo recibido desde log = " + angleValue + " | texto: " + message);
		}
	}

	private void OnApplicationQuit()
	{
		Application.logMessageReceivedThreaded -= HandleLogMessage;
	}
}
