using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            OnAnyKeyPressed();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void OnAnyKeyPressed()
    {
        Debug.Log("Key pressed!");
        
        SceneManager.LoadScene(1);
    }
}
