    using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue NPC", menuName = "Dialogue NPC")]
    public class DialogueNPC : ScriptableObject
    {
        public string npcName;
        public Sprite npcSprite;
        public string[] dialogueLines;
        public float typingSpeed = 0.05f;
        public bool[] autoProgress;
        public float autoProgressDelay = 2f;

    }
