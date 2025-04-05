using UnityEngine;
using TMPro;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text.RegularExpressions;

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
    public void CheckRanking(int winStreak, PostRankingFlag prf)
    {
        StartCoroutine(CallCheckAPI(winStreak, prf));
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
            text.text = currentRanking;
        }
        else
        {
            string responseText = request.downloadHandler.text;

            // JSONレスポンスをデシリアライズして表示
            try
            {
                // レスポンスがJSONの場合、デシリアライズしてオブジェクトとして処理
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                currentRanking = jsonResponse.body;
                text.text = Conversion(currentRanking);
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
        string jsonPayload = "{\"ranking\": \"1位,40連勝,ぱちぱち,2位,8連勝,ぱっち\"}";

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

    IEnumerator CallCheckAPI(int winstreak, PostRankingFlag prf)
    {
        // GETリクエストの送信
        UnityWebRequest request = UnityWebRequest.Get(getUrl);  // GETリクエストを使う
        request.timeout = 10;

        yield return request.SendWebRequest();
        Debug.Log("Rankngを取得した結果: " + request.result);

        // エラーハンドリング
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + request.error);
        }
        else
        {
            string responseText = request.downloadHandler.text;

            // JSONレスポンスをデシアライズ
            try
            {
                // レスポンスがJSONの場合、デシリアライズしてオブジェクトとして処理
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                // 今までのランキングを格納する辞書を作成
                Dictionary<int, Score> scores = GetScore(jsonResponse.body);
                prf.Flag = CompareScore(winstreak, scores);
                
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
            }
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
    Dictionary<int, Score> GetScore(string ranking)
    {
        var pattern = @"(\d+)位,(\d+)連勝,([^,]+)";

        // 正規表現で全ての一致を検索
        MatchCollection matches = Regex.Matches(ranking, pattern);
        Dictionary<int, Score> scores = new Dictionary<int, Score>();

        // 各マッチから連勝数と名前を取り出して辞書に格納
        foreach (Match match in matches)
        {
            int rank = int.Parse(match.Groups[1].Value);        // 順位
            int winStreak = int.Parse(match.Groups[2].Value);   // 連勝数
            string name = match.Groups[3].Value;                // 名前

            scores[rank] = new Score(rank, winStreak, name);
        }
        return scores;
        
    }

    // 2を返したらランキング更新可能
    // 1を返したらランキング更新不可
    int CompareScore(int winStreak, Dictionary<int, Score> scores)
    {
        // いずれかのスコアより高ければ更新可能
        int scoreCount = 0;
        foreach (var score in scores)
        {
            scoreCount++;
            if(score.Value.WinStreak < winStreak)
            {
                return 2;
            }
        }

        //ランキングが9件未満なら追加できる
        if (scoreCount < 9)
        {
            return 2;
        }
        return 1;
    }

    public class Score
    {
        public int Rank { get; set; }
        public int WinStreak { get; set; }
        public string Name { get; set; }

        public Score(int rank,int winStreak, string name)
        {
            Rank = rank;
            WinStreak = winStreak;
            Name = name;
        }
    }
    // Lambdaのレスポンス構造に合わせたクラス
    [System.Serializable]
    public class LambdaResponse
    {
        public int statusCode;
        public string body;
    }
}
