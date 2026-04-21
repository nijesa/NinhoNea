using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] SceneManager sceneManager;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            OnAnyKeyPressed();
        }
    }

    void OnAnyKeyPressed()
    {
        Debug.Log("Key pressed!");
        
        sceneManager.LoadScene(0);
    }
}
