using UnityEngine;

public class DialogStarter : MonoBehaviour
{
    public DialogManager dialogueManager;

    void Start()
    {
        DialogueNode[] dialogueNodes = new DialogueNode[]
        {
            new DialogueNode
            {
                dialogueText = "Привет! Как дела?",
                options = new DialogueOption[]
                {
                    new DialogueOption { optionText = "Отлично!", nextNodeIndex = 1 },
                    new DialogueOption { optionText = "Не очень...", nextNodeIndex = 2 }
                }
            },
            new DialogueNode
            {
                dialogueText = "Рад слышать!",
                options = new DialogueOption[] { }
            },
            new DialogueNode
            {
                dialogueText = "Не расстраивайся, все наладится!",
                options = new DialogueOption[] { }
            }
        };

        dialogueManager.StartDialogue(dialogueNodes);
    }
}