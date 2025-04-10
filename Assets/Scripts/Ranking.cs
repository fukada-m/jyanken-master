using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class Ranking : MonoBehaviour
{
    string getUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Get";
    string postUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Post";
    string currentRanking;

    public void GetRanking(TMP_Text text)
    {
        StartCoroutine(CallGetAPI(text));
    }

    public void PostRanking(int winStreak, string userName, PostRankingButton prb)
    {
        StartCoroutine(CallPostAPI(winStreak, userName, prb));
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
                // 配列ラップ → JsonUtilityで読み込む
                string wrappedJson = "{\"items\":" + responseText + "}";
                BodyItemArrayWrapper wrapped = JsonUtility.FromJson<BodyItemArrayWrapper>(wrappedJson);
                foreach (var item in wrapped.items)
                {
                    currentRanking += $"{item.rank}位 {item.streak}連勝  {item.name}\n";
                }
                text.text = currentRanking;
                // ""を代入しないとボタンを押すたびにランキングが足される
                currentRanking = "";

            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
                text.text = "ランキングの取得に失敗しました。\n 管理者に連絡してください。";
            }
        }
    }

    IEnumerator CallPostAPI(int winStreak, string userName, PostRankingButton prb)
    {
        var jsonPayload = "{\"name\": \"" + userName +"\",\"streak\": \""+ winStreak +"\"}";
        Debug.Log("登録する文字列：" + jsonPayload);


        // POSTリクエストの送信
        UnityWebRequest postRequest = new UnityWebRequest(postUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        postRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        postRequest.downloadHandler = new DownloadHandlerBuffer();
        postRequest.SetRequestHeader("Content-Type", "application/json");

        // レスポンスを待機
        yield return postRequest.SendWebRequest();

        // エラーハンドリング
        if (postRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + postRequest.error);
            prb.Flag = true;
            prb.DispPushAgain();
        }
        else
        {
            // レスポンスの内容を表示
            Debug.Log("API Response: " + postRequest.downloadHandler.text);
            // シーンを再読み込み
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
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
                // 配列ラップ → JsonUtilityで読み込む
                string wrappedJson = "{\"items\":" + responseText + "}";
                BodyItemArrayWrapper wrapped = JsonUtility.FromJson<BodyItemArrayWrapper>(wrappedJson);

                prf.Flag = CompareScore(winstreak, wrapped.items);
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
            }
        }
    }

    // 2を返したらランキング更新可能
    // 1を返したらランキング更新不可
    int CompareScore(int winStreak, BodyItem[] items)
    {
        // いずれかのスコアより高ければ更新可能
        foreach (var body in items)
        {
            if (body.streak < winStreak)
            {
                return 2;
            }
        }

        //ランキングが9件未満なら追加できる
        if (items.Length < 9)
        {
            return 2;
        }
        // どちらかの条件を満たさなければランキング更新不可
        return 1;
    }

    // 多分削除してよい
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
    // 多分削除してよい
    [Serializable]
    public class LambdaResponse
    {
        public int statusCode;
        public string body;
    }

    // body 内のアイテム構造
    [Serializable]
    public class BodyItem
    {
        public string ID;
        public int streak;
        public string name;
        public int rank;
    }

    [Serializable]
    public class BodyItemArrayWrapper
    {
        public BodyItem[] items;
    }
}
