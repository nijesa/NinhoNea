using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TP_Scene : MonoBehaviour
{
    
    [SerializeField] int sceneIndex;
   
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
