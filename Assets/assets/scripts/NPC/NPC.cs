using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.Events;


public class NPC : MonoBehaviour
{
    public DialogueNPC dialogueData;
    public GameObject dialogueUI;
    public TMP_Text dialogueText, nameText;
    public PauseScript pauseScript;
    public UnityEvent onDialogueFinished;
    private bool firstTime = true;

    private int dialogueIndex = 0;
    private bool isTyping, isDialogueActive;

    void OnEnable()
    {
        if (firstTime)
        {
            firstTime = false;
            StartDialogue();
        }
        
    }
    void StartDialogue()
    {
        Debug.Log("Start Dialogue");
        isDialogueActive = true;
        dialogueIndex = 0;
        nameText.text = dialogueData.npcName;
        dialogueUI.SetActive(true);
        pauseScript.PauseGame();
        StartCoroutine(TypeLine());
        
    }
    
    void NextLine()
    {
        
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if (dialogueIndex+1<dialogueData.dialogueLines.Length)
        {
           
           
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
       
    }
    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in dialogueData.dialogueLines[dialogueIndex])
        {
            
            dialogueText.text += letter;
            yield return new WaitForSecondsRealtime(0.05f);
        }
        isTyping = false;
        if (dialogueData.autoProgress.Length > dialogueIndex && dialogueData.autoProgress[dialogueIndex])
        {
            yield return new WaitForSecondsRealtime(dialogueData.autoProgressDelay);
            dialogueIndex++;
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        isDialogueActive = false;
        if (onDialogueFinished != null)
        {
            onDialogueFinished.Invoke();
        }
        dialogueUI.SetActive(false);
        gameObject.SetActive(false);
        pauseScript.ResumeGame();
    }

}
