using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class NPCSystem : MonoBehaviour
{
    public UnityEvent onEnter;
     public UnityEvent onExit;
     public UnityEvent onInteract;
    bool playerInRange = false;
    [SerializeField] GameObject cosaPaVer;
    [SerializeField] GameObject cosaPaVer2;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject[] OtherOptions;
    [SerializeField] GameObject InvisiWall;

    bool PlayerChose = false;
    Coroutine waitCoroutine;
    [SerializeField] Image progressBar;


    void Start()
    {
        if (progressBar != null)
        {
            progressBar.fillAmount = 1f;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playerInRange)
        {
            cosaPaVer.SetActive(true);
            cosaPaVer2.SetActive(true);
           // Debug.Log("Interacting with NPC");
            if (PlayerChose == true)
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
                if (onInteract != null)
                {
                    onInteract.Invoke();
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
            if (progressBar != null)
            {
                progressBar.gameObject.SetActive(true);
                progressBar.fillAmount = 1f;
            }
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
            PlayerChose = false;

            if (waitCoroutine != null)
            {
                StopCoroutine(waitCoroutine);
                waitCoroutine = null;
            }
            if (progressBar != null)
            {
                progressBar.fillAmount = 1f;
                
            }

            Debug.Log("Player left range");
            if (onExit != null)
            {
                onExit.Invoke();
            }
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player") || PlayerChose)
        {
            return;
        }

        if (waitCoroutine == null)
        {
            waitCoroutine = StartCoroutine(esperarUnRatico());
        }
    }

    IEnumerator esperarUnRatico()
    {
        float duration = 3f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (!playerInRange)
            {
                if (progressBar != null)
                    progressBar.fillAmount = 0f;
                waitCoroutine = null;
                yield break;
            }

            elapsed += Time.deltaTime;
            if (progressBar != null)
                progressBar.fillAmount = Mathf.Clamp01(1f - (elapsed / duration));

            yield return null;
        }

        if (playerInRange)
        {
            PlayerChose = true;
        }

        if (progressBar != null)
            progressBar.fillAmount = 0f;

        waitCoroutine = null;
    }
}
