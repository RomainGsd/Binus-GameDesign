using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SaveButtonHandler : MonoBehaviour
{
    readonly string targetURL = "https://coralisstudio.com/agdp.php";

    public void OnButtonSendScore()
    {
        StartCoroutine(uploadScore());
    }
    private IEnumerator uploadScore()
    {
        WWWForm form = new WWWForm();
        form.AddField("api_key", "coralis0912");
        form.AddField("player_name", "ROMAIN GOASDOUE");
        form.AddField("score", ScoreManager.scoreValue);
        form.AddField("student_id", "2301956815");
        var request = UnityWebRequest.Post(targetURL, form);
        yield return request.SendWebRequest();
        Debug.Log(request.isNetworkError || request.isHttpError ? "Error: " + request.error : request.downloadHandler.text);
    }
}
