using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System.Text.RegularExpressions;
using System;

public class Ranking : MonoBehaviour
{
    string getUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Get";
    string postUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Post";
    string currentRanking;

    public void GetRanking(TMP_Text text)
    {
        StartCoroutine(CallGetAPI(text));
    }

    public void PostRanking(int winStreak, string userName)
    {
        StartCoroutine(CallPostAPI(winStreak, userName));
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
            Debug.Log("responseText:" + responseText);

            // JSONレスポンスをデシリアライズして表示
            try
            {
                // レスポンスがJSONの場合、デシリアライズしてオブジェクトとして処理
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                foreach (var item in jsonResponse.body)
                {
                    currentRanking += $"{item.rank}位 {item.streak}連勝  {item.name}\n";
                }
                text.text = currentRanking;

            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
                text.text = "ランキングの取得に失敗しました。\n もう一度ランキングボタンを押してください。";
            }
        }
    }

    IEnumerator CallPostAPI(int winStreak, string userName)
    {
        string jsonPayload = "";
        // GETリクエストの送信
        UnityWebRequest getRequest = UnityWebRequest.Get(getUrl);  // GETリクエストを使う
        getRequest.timeout = 10;
        yield return getRequest.SendWebRequest();
        Debug.Log("Rankngを取得した結果: " + getRequest.result);

        // エラーハンドリング
        if (getRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + getRequest.error);
        }
        else
        {
            string responseText = getRequest.downloadHandler.text;

            // JSONレスポンスをデシアライズ
            try
            {
                // レスポンスがJSONの場合、デシリアライズしてオブジェクトとして処理
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                // 今までのランキングを格納する辞書を作成
                //Dictionary<int, Score> scores = GetScore(jsonResponse.body);
                //int rankingNumber = CalcScore(winStreak, scores);
                //jsonPayload = MakeRankingText(rankingNumber, winStreak, userName, scores);

            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
            }
        }
        jsonPayload = "{\"ranking\": \"" + jsonPayload + "\"}";
        Debug.Log("登録する文字列：" + jsonPayload);
        // 送信するデータ
        //jsonPayload = "{\"ranking\": \"1位,40連勝,ぱちぱち,2位,8連勝,ぱっち\"}";

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
                //Dictionary<int, Score> scores = GetScore(jsonResponse.body);
                //prf.Flag = CompareScore(winstreak, scores);
                
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
            }
        }
    }

    string Conversion (string currentRanking)
    {
        //string[] parts = currentRanking.Split(',');
        //StringBuilder sb = new StringBuilder();
        //for (int i = 0; i < parts.Length; i += 3)
        //{
        //    // 安全確認（要素数が3の倍数でない場合にも対応）
        //    if (i + 2 < parts.Length)
        //    {
        //        sb.AppendLine($"{parts[i]} {parts[i + 1]} {parts[i + 2]}");
        //    }
        //}
        //string result = sb.ToString();
        //return result;
        return "";
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

    int CalcScore(int winStreak, Dictionary<int, Score> scores)
    {
        // 自分より高いスコアの数を数える
        int scoreCount = 1;
        foreach (var score in scores)
        {
            if (score.Value.WinStreak > winStreak)
            {
                scoreCount++;
            }
        }
        // 自分の順位を返す
        return scoreCount;
    }

    string MakeRankingText(int num, int winStreak, string name, Dictionary<int, Score> scores)
    {
        string rankingText = "";
        foreach (var score in scores)
        {
            // 既存のランキングを更新
            if (score.Value.Rank < num)
            {
                // Getした値をそのまま
                rankingText += $"{score.Value.Rank}位,{score.Value.WinStreak}連勝,{score.Value.Name},";
            }
            else if (score.Value.Rank == num)
            {
                // 新しくランキングに追加する値
                rankingText += $"{num}位,{winStreak}連勝,{name},";
                //既存の値はランキングに+1する
                rankingText += $"{score.Value.Rank + 1}位,{score.Value.WinStreak}連勝,{score.Value.Name},";
            }
            else
            {
                // 今の順位に+1した順位にする
                rankingText += $"{score.Value.Rank + 1}位,{score.Value.WinStreak}連勝,{score.Value.Name},";
            }

        }
        // 最下位に追加したい場合の処理
        if (num > scores.Count)
        {
            rankingText += $"{num}位,{winStreak}連勝,{name},";
        }
        return rankingText;
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
    [Serializable]
    public class LambdaResponse
    {
        public int statusCode;
        public BodyItem[] body;
    }

    // body 内のアイテム構造
    [Serializable]
    public class BodyItem
    {
        public int ID;
        public int streak;
        public string name;
        public int rank;
    }
}
