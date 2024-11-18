using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class select : MonoBehaviour
{
    string URL = "D:/new buckshoot roullet/db/select.php";
    public string[] data;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        UnityWebRequest game = new UnityWebRequest(URL);
        yield return game;
        string gamedatastring = game.ToString();
        data = gamedatastring.Split(";");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
