using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PostRankingButton : MonoBehaviour
{
    string apiUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Post";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void OnClickButton()
    {
        StartCoroutine(CallAPI());
    }
    IEnumerator CallAPI()
    {
        // 送信するデータ
        string jsonPayload = "{\"ranking\": \"1位,4連勝,ぱちぱち\"}";

        // POSTリクエストの送信
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // レスポンスを待機
        yield return request.SendWebRequest();

        // エラーハンドリング
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + request.error);
        }
        else
        {
            // レスポンスの内容を表示
            Debug.Log("API Response: " + request.downloadHandler.text);
        }
    }
}
