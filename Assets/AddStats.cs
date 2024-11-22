using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
public class ApiConnector : MonoBehaviour
{
    private string apiUrl = "http://127.0.0.1:5000/addstats"; // Замените на ваш URL
    public Animator animator;
    public Animator animator2;
    bool can = true;
    void Start()
    {
        can = true;
        // Пример данных для отправки
        var dataToSend = new { score = animator.GetInteger("score")};
        //StartCoroutine(PostDataToApi(dataToSend));
    }
    public void Update()
    {
        if (animator.GetBool("fulldeath") || animator2.GetBool("fulldeath"))
        {
            if (can == true)
            {
                can = false;   
                PostData();
                StartCoroutine(Wait());
            }
            
        }
            
    }

    [Serializable]
    public class Quark
    {
        public string score;
    }

    public void PostData()
    {

        Quark gamer = new Quark();
        gamer.score = animator.GetInteger("score").ToString();

        string json = JsonUtility.ToJson(gamer);
        StartCoroutine(PostRequest("http://127.0.0.1:5000/addstats", json));
    }

    IEnumerator PostRequest(string url, string json)
    {
        var uwr = new UnityWebRequest(url, "POST");
        byte[] jsonToSend = new System.Text.UTF8Encoding().GetBytes(json);
        uwr.uploadHandler = (UploadHandler)new UploadHandlerRaw(jsonToSend);
        uwr.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        uwr.SetRequestHeader("Content-Type", "application/json");

        //Send the request then wait here until it returns
        yield return uwr.SendWebRequest();

        if (uwr.isNetworkError)
        {
            Debug.Log("Error While Sending: " + uwr.error);
        }
        else
        {
            Debug.Log("Received: " + uwr.downloadHandler.text);
        }
    }
    IEnumerator Wait()
    {

        yield return new WaitForSeconds(0.7f);
        SceneManager.LoadScene("menu");
    }
}

