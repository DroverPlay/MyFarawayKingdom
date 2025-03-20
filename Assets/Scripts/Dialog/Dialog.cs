using System;

[Serializable]
public class DialogueNode
{
    public string speakerName; // Имя говорящего
    public string dialogueText; // Текст реплики
    public DialogueOption[] options; // Варианты ответов
}

[Serializable]
public class DialogueOption
{
    public string optionText; // Текст варианта ответа
    public int nextNodeIndex; // Индекс следующей реплики
}
