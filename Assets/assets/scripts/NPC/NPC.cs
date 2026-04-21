using UnityEngine;
using TMPro;
using System.Collections;
using JetBrains.Annotations;

public class NPC : MonoBehaviour
{
    public DialogueNPC dialogueData;
    public GameObject dialogueUI;
    public TMP_Text dialogueText, nameText;
    public PauseScript pauseScript;

    private int dialogueIndex = 0;
    private bool isTyping, isDialogueActive;

    void OnEnable()
    {
        StartDialogue();
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
        Debug.Log("Next Line");
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(dialogueData.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if (dialogueIndex+1<dialogueData.dialogueLines.Length)
        {
            Debug.Log("Next Line Else If");
           
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
        dialogueUI.SetActive(false);
        gameObject.SetActive(false);
        pauseScript.ResumeGame();
    }

}
