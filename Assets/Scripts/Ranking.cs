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
        // GET���N�G�X�g�̑��M
        UnityWebRequest request = UnityWebRequest.Get(getUrl);  // GET���N�G�X�g���g��
        request.timeout = 10;

        yield return request.SendWebRequest();
        Debug.Log("GetRankng���s��������: " + request.result);

        // �G���[�n���h�����O
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + request.error);
            currentRanking = "�����L���O�̎擾�Ɏ��s���܂����B\n ������x�����L���O�{�^���������Ă��������B";
            text.text = currentRanking;
        }
        else
        {
            string responseText = request.downloadHandler.text;
            Debug.Log("responseText:" + responseText);

            // JSON���X�|���X���f�V���A���C�Y���ĕ\��
            try
            {
                // ���X�|���X��JSON�̏ꍇ�A�f�V���A���C�Y���ăI�u�W�F�N�g�Ƃ��ď���
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                foreach (var item in jsonResponse.body)
                {
                    currentRanking += $"{item.rank}�� {item.streak}�A��  {item.name}\n";
                }
                text.text = currentRanking;

            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
                text.text = "�����L���O�̎擾�Ɏ��s���܂����B\n ������x�����L���O�{�^���������Ă��������B";
            }
        }
    }

    IEnumerator CallPostAPI(int winStreak, string userName)
    {
        string jsonPayload = "";
        // GET���N�G�X�g�̑��M
        UnityWebRequest getRequest = UnityWebRequest.Get(getUrl);  // GET���N�G�X�g���g��
        getRequest.timeout = 10;
        yield return getRequest.SendWebRequest();
        Debug.Log("Rankng���擾��������: " + getRequest.result);

        // �G���[�n���h�����O
        if (getRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + getRequest.error);
        }
        else
        {
            string responseText = getRequest.downloadHandler.text;

            // JSON���X�|���X���f�V�A���C�Y
            try
            {
                // ���X�|���X��JSON�̏ꍇ�A�f�V���A���C�Y���ăI�u�W�F�N�g�Ƃ��ď���
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                // ���܂ł̃����L���O���i�[���鎫�����쐬
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
        Debug.Log("�o�^���镶����F" + jsonPayload);
        // ���M����f�[�^
        //jsonPayload = "{\"ranking\": \"1��,40�A��,�ς��ς�,2��,8�A��,�ς���\"}";

        // POST���N�G�X�g�̑��M
        UnityWebRequest request = new UnityWebRequest(postUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        // ���X�|���X��ҋ@
        yield return request.SendWebRequest();

        // �G���[�n���h�����O
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + request.error);
        }
        else
        {
            // ���X�|���X�̓��e��\��
            Debug.Log("API Response: " + request.downloadHandler.text);
        }
    }

    IEnumerator CallCheckAPI(int winstreak, PostRankingFlag prf)
    {
        // GET���N�G�X�g�̑��M
        UnityWebRequest request = UnityWebRequest.Get(getUrl);  // GET���N�G�X�g���g��
        request.timeout = 10;

        yield return request.SendWebRequest();
        Debug.Log("Rankng���擾��������: " + request.result);

        // �G���[�n���h�����O
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + request.error);
        }
        else
        {
            string responseText = request.downloadHandler.text;

            // JSON���X�|���X���f�V�A���C�Y
            try
            {
                // ���X�|���X��JSON�̏ꍇ�A�f�V���A���C�Y���ăI�u�W�F�N�g�Ƃ��ď���
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                // ���܂ł̃����L���O���i�[���鎫�����쐬
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
        //    // ���S�m�F�i�v�f����3�̔{���łȂ��ꍇ�ɂ��Ή��j
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
        var pattern = @"(\d+)��,(\d+)�A��,([^,]+)";

        // ���K�\���őS�Ă̈�v������
        MatchCollection matches = Regex.Matches(ranking, pattern);
        Dictionary<int, Score> scores = new Dictionary<int, Score>();

        // �e�}�b�`����A�����Ɩ��O�����o���Ď����Ɋi�[
        foreach (Match match in matches)
        {
            int rank = int.Parse(match.Groups[1].Value);        // ����
            int winStreak = int.Parse(match.Groups[2].Value);   // �A����
            string name = match.Groups[3].Value;                // ���O

            scores[rank] = new Score(rank, winStreak, name);
        }
        return scores;
        
    }

    // 2��Ԃ����烉���L���O�X�V�\
    // 1��Ԃ����烉���L���O�X�V�s��
    int CompareScore(int winStreak, Dictionary<int, Score> scores)
    {
        // �����ꂩ�̃X�R�A��荂����΍X�V�\
        int scoreCount = 0;
        foreach (var score in scores)
        {
            scoreCount++;
            if(score.Value.WinStreak < winStreak)
            {
                return 2;
            }
        }

        //�����L���O��9�������Ȃ�ǉ��ł���
        if (scoreCount < 9)
        {
            return 2;
        }
        return 1;
    }

    int CalcScore(int winStreak, Dictionary<int, Score> scores)
    {
        // ������荂���X�R�A�̐��𐔂���
        int scoreCount = 1;
        foreach (var score in scores)
        {
            if (score.Value.WinStreak > winStreak)
            {
                scoreCount++;
            }
        }
        // �����̏��ʂ�Ԃ�
        return scoreCount;
    }

    string MakeRankingText(int num, int winStreak, string name, Dictionary<int, Score> scores)
    {
        string rankingText = "";
        foreach (var score in scores)
        {
            // �����̃����L���O���X�V
            if (score.Value.Rank < num)
            {
                // Get�����l�����̂܂�
                rankingText += $"{score.Value.Rank}��,{score.Value.WinStreak}�A��,{score.Value.Name},";
            }
            else if (score.Value.Rank == num)
            {
                // �V���������L���O�ɒǉ�����l
                rankingText += $"{num}��,{winStreak}�A��,{name},";
                //�����̒l�̓����L���O��+1����
                rankingText += $"{score.Value.Rank + 1}��,{score.Value.WinStreak}�A��,{score.Value.Name},";
            }
            else
            {
                // ���̏��ʂ�+1�������ʂɂ���
                rankingText += $"{score.Value.Rank + 1}��,{score.Value.WinStreak}�A��,{score.Value.Name},";
            }

        }
        // �ŉ��ʂɒǉ��������ꍇ�̏���
        if (num > scores.Count)
        {
            rankingText += $"{num}��,{winStreak}�A��,{name},";
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
    // Lambda�̃��X�|���X�\���ɍ��킹���N���X
    [Serializable]
    public class LambdaResponse
    {
        public int statusCode;
        public BodyItem[] body;
    }

    // body ���̃A�C�e���\��
    [Serializable]
    public class BodyItem
    {
        public int ID;
        public int streak;
        public string name;
        public int rank;
    }
}
