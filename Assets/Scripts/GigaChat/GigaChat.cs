using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class GigaChat : MonoBehaviour
{
    [SerializeField] private TMP_Text responseText;
    private const string API_URL = "https://gigachat.devices.sberbank.ru/api/v1/chat/completions";
    private const string API_KEY = "NmFkZmM2OTQtMGI2Yi00NDlkLWIwYjAtMzQ0Y2U5YmRkNjk0OjAyMjQ1NTc0LTkzNDctNGY1ZS1iZmRjLTQ3OWU2NWI5ODA4ZA==";

    public void SendRequestToGigaChat(string prompt)
    {
        StartCoroutine(SendChatRequest(prompt));
    }

    private IEnumerator SendChatRequest(string prompt)
    {
        string jsonRequest = JsonUtility.ToJson(new RequestData
        {
            model = "GigaChat",
            messages = new Message[]
            {
                new Message { role = "user", content = prompt }
            }
        });

        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonRequest);

        UnityWebRequest request = new UnityWebRequest(API_URL, "POST");
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", API_KEY);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("Ответ от GigaChat: " + request.downloadHandler.text);
            var response = JsonUtility.FromJson<ResponseData>(request.downloadHandler.text);
            string reply = response.choices[0].message.content;
            Debug.Log("Ответ: " + response.choices[0].message.content);

            if (responseText != null)
                responseText.text = reply;
            else
                Debug.LogWarning("Не назначен Text элемент в Inspector!");
        }
        else
        {
            Debug.LogError("Ошибка: " + request.error);
        }
    }
}

[System.Serializable]
public class RequestData
{
    public string model;
    public Message[] messages;
}

[System.Serializable]
public class Message
{
    public string role;
    public string content;
}

[System.Serializable]
public class ResponseData
{
    public Choice[] choices;
}

[System.Serializable]
public class Choice
{
    public Message message;
}