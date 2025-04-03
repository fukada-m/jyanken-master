using UnityEngine;
using TMPro;
using System.Text;
using System.Collections;
using UnityEngine.Networking;

public class Ranking : MonoBehaviour
{
    string getUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Get";
    string postUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Post";
    string currentRanking;

    public void GetRanking(TMP_Text text)
    {
        StartCoroutine(CallGetAPI(text));
    }

    public void PostRanking()
    {
        StartCoroutine(CallPostAPI());
    }

    IEnumerator CallGetAPI(TMP_Text text)
    {
        // GETリクエストの送信
        UnityWebRequest request = UnityWebRequest.Get(getUrl);  // GETリクエストを使う
        request.timeout = 10;

        yield return request.SendWebRequest();
        Debug.Log("GetRankngを行った結果: " + request.result);

        // エラーハンドリング
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + request.error);
            currentRanking = "ランキングの取得に失敗しました。\n もう一度ランキングボタンを押してください。";
            text.text = Conversion(currentRanking);
        }
        else
        {
            string responseText = request.downloadHandler.text;

            // JSONレスポンスをデシリアライズして表示
            try
            {
                // レスポンスがJSONの場合、デシリアライズしてオブジェクトとして処理
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                text.text = jsonResponse.body;
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
                text.text = "ランキングの取得に失敗しました。\n もう一度ランキングボタンを押してください。";
            }
        }
    }

    IEnumerator CallPostAPI()
    {
        // 送信するデータ
        string jsonPayload = "{\"ranking\": \"1位,4連勝,ぱちぱち\"}";

        // POSTリクエストの送信
        UnityWebRequest request = new UnityWebRequest(postUrl, "POST");
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

    string Conversion (string currentRanking)
    {
        string[] parts = currentRanking.Split(',');
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < parts.Length; i += 3)
        {
            // 安全確認（要素数が3の倍数でない場合にも対応）
            if (i + 2 < parts.Length)
            {
                sb.AppendLine($"{parts[i]} {parts[i + 1]} {parts[i + 2]}");
            }
        }
        string result = sb.ToString();
        return result;
    }
}
