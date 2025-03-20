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
                dialogueText = "������! ��� ����?",
                options = new DialogueOption[]
                {
                    new DialogueOption { optionText = "�������!", nextNodeIndex = 1 },
                    new DialogueOption { optionText = "�� �����...", nextNodeIndex = 2 }
                }
            },
            new DialogueNode
            {
                dialogueText = "��� �������!",
                options = new DialogueOption[] { }
            },
            new DialogueNode
            {
                dialogueText = "�� �������������, ��� ���������!",
                options = new DialogueOption[] { }
            }
        };

        dialogueManager.StartDialogue(dialogueNodes);
    }
}