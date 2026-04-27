using UnityEngine;
using WebSocketSharp;

public class WebSocketClient : MonoBehaviour
{
    WebSocket ws;

    [System.Serializable]
    public class Data
    {
        public float x;
    }

    void Start()
    {
        ws = new WebSocket("ws://localhost:3000");

        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("Conectado al servidor");
        };

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("Mensaje crudo: " + e.Data);

            try
            {
                Data data = JsonUtility.FromJson<Data>(e.Data);
                Debug.Log("X recibida: " + data.x);
            }
            catch
            {
                Debug.LogWarning("Error parseando JSON");
            }
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("Conexión cerrada");
        };

        ws.OnError += (sender, e) =>
        {
            Debug.LogError("Error: " + e.Message);
        };

        ws.Connect();
    }

    void OnApplicationQuit()
    {
        if (ws != null)
            ws.Close();
    }
}