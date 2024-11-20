using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using MySql.Data.MySqlClient;
using System.Net;
using UnityEngine.Networking;

public class Test : MonoBehaviour
{
    private string apiUrl = "http://127.0.0.1:5000/stats"; // �������� �� ��� URL

    void Start()
    {
        StartCoroutine(GetDataFromApi());
    }

    private IEnumerator GetDataFromApi()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            // �������� ������� � �������� ������
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                // ��������� ������
                Debug.Log("Response: " + webRequest.downloadHandler.text);
            }
        }
    }

}