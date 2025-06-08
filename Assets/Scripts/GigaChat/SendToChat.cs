using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SendToChat : MonoBehaviour
{
    [SerializeField] private TMP_Text m_TextMeshPro;
    private string m_Text;
    public void message()
    {
        m_Text = m_TextMeshPro.text;
        GetComponent<GigaChat>().SendRequestToGigaChat(m_Text);
    }
}
