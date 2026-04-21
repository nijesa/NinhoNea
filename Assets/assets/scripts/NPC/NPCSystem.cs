using Unity.VisualScripting;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    bool playerInRange = false;
    [SerializeField] GameObject cosaPaVer;
    [SerializeField] GameObject Dialogue;

    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            cosaPaVer.SetActive(true);
           // Debug.Log("Interacting with NPC");
            if (Input.GetKeyDown(KeyCode.E))
            {
                Dialogue.SetActive(true);
                
            }
        }
        else
        {
            cosaPaVer.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player in range");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range");
        }
    }
}
