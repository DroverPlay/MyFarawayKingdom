using System;

[Serializable]
public class DialogueNode
{
    public string speakerName; // ��� ����������
    public string dialogueText; // ����� �������
    public DialogueOption[] options; // �������� �������
}

[Serializable]
public class DialogueOption
{
    public string optionText; // ����� �������� ������
    public int nextNodeIndex; // ������ ��������� �������
}
