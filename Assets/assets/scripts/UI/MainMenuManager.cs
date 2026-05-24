using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private int inex;
    void Update()
    {
        if (Input.anyKeyDown)
        {
            OnAnyKeyPressed();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(inex);
    }

    void OnAnyKeyPressed()
    {
        Debug.Log("Key pressed!");
        
        SceneManager.LoadScene(inex);
    }
}
