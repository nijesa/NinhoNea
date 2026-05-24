using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private int inex;
    
    

    public void StartGame()
    {
        SceneManager.LoadScene(inex);
    }

    public void OnAnyKeyPressed()
    {
        Debug.Log("Key pressed!");
        
        SceneManager.LoadScene(inex);
    }
}
