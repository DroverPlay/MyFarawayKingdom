using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public TMP_Text dialogueText; // UI ������� ��� ����������� ������ �������
    public Button[] optionButtons; // ������ ��� ��������� ������

    private DialogueNode[] dialogueNodes; // ������ ������ �������
    private int currentNodeIndex = 0; // ������ ������� �������

    public void StartDialogue(DialogueNode[] nodes)
    {
        dialogueNodes = nodes;
        currentNodeIndex = 0;
        DisplayCurrentNode();
    }

    private void DisplayCurrentNode()
    {
        DialogueNode currentNode = dialogueNodes[currentNodeIndex];
        dialogueText.text = currentNode.dialogueText;

        foreach (var button in optionButtons)
        {
            button.gameObject.SetActive(false);
        }

        for (int i = 0; i < currentNode.options.Length; i++)
        {
            optionButtons[i].gameObject.SetActive(true);
            optionButtons[i].GetComponentInChildren<TMP_Text>().text = currentNode.options[i].optionText;
            int optionIndex = i; 
            optionButtons[i].onClick.RemoveAllListeners();
            optionButtons[i].onClick.AddListener(() => OnOptionSelected(optionIndex));
        }
    }

    private void OnOptionSelected(int optionIndex)
    {
        int nextNodeIndex = dialogueNodes[currentNodeIndex].options[optionIndex].nextNodeIndex;
        if (nextNodeIndex >= 0 && nextNodeIndex < dialogueNodes.Length)
        {
            currentNodeIndex = nextNodeIndex;
            DisplayCurrentNode();
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        Debug.Log("������ ��������.");
    }
}