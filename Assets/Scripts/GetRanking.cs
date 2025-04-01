using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System;
using System.Text;
using TMPro;



public class GetRanking : MonoBehaviour
{
    string apiUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Get";
    TMP_Text rankingText;
    string result;

    void Start()
    {
        
    }

    public void DispRanking(TMP_Text rankingText)
    {
        this.rankingText = rankingText;
        StartCoroutine(CallAPI());
    }

    IEnumerator CallAPI()
    {
        // GETリクエストの送信
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);  // GETリクエストを使う
        request.timeout = 10;
        // レスポンスを待機
        yield return request.SendWebRequest();
        Debug.Log("Get ranking request.result: " + request.result);

        // エラーハンドリング
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + request.error);
            rankingText.text = "ランキングの取得に失敗しました。\n もう一度ランキングボタンを押してください。";
        }
        else
        {
            string responseText = request.downloadHandler.text;

            // JSONレスポンスをデシリアライズして表示
            try
            {
                // レスポンスがJSONの場合、デシリアライズしてオブジェクトとして処理
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                result = jsonResponse.body;
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
                rankingText.text = "ランキングの取得に失敗しました。\n もう一度ランキングボタンを押してください。";
            }
        }
        result = Conversion(result);
        rankingText.text = result;
    }
    // ,をスペースに変換して 3つ毎に改行する
    string Conversion(string body)
    {
        string[] parts = body.Split(',');
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

// Lambdaのレスポンス構造に合わせたクラス
[System.Serializable]
public class LambdaResponse
{
    public int statusCode;
    public string body;
}
