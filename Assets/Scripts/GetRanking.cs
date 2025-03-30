using UnityEngine;
using UnityEngine.Networking;
using System.Collections;



public class GetRanking : MonoBehaviour
{
    private string apiUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken";
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
        // GETリクエストの送信
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);  // GETリクエストを使う

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
            string responseText = request.downloadHandler.text;
            Debug.Log("API Response (raw): " + responseText);

            // JSONレスポンスをデシリアライズして表示
            try
            {
                // レスポンスがJSONの場合、デシリアライズしてオブジェクトとして処理
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                Debug.Log("Lambda Response Body: " + jsonResponse.body);  // ここでbodyの内容を表示
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
            }
        }
    }
}

// Lambdaのレスポンス構造に合わせたクラス
[System.Serializable]
public class LambdaResponse
{
    public int statusCode;
    public string body;
}
