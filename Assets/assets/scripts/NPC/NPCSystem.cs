using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class NPCSystem : MonoBehaviour
{
    public UnityEvent onEnter;
     public UnityEvent onExit;
    bool playerInRange = false;
    [SerializeField] GameObject cosaPaVer;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject[] OtherOptions;
    [SerializeField] GameObject InvisiWall;

    

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
                if (OtherOptions != null)
                {
                    foreach (GameObject option in OtherOptions)
                    {
                        option.SetActive(false);
                    }
                }
                if (InvisiWall != null)
                {
                    InvisiWall.SetActive(false);
                }
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
            if (onEnter != null)
            {
                onEnter.Invoke();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range");
            if (onExit != null)
            {
                onExit.Invoke();
            }
        }
    }
}
