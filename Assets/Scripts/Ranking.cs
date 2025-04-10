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
                // �z�񃉃b�v �� JsonUtility�œǂݍ���
                string wrappedJson = "{\"items\":" + responseText + "}";
                BodyItemArrayWrapper wrapped = JsonUtility.FromJson<BodyItemArrayWrapper>(wrappedJson);
                foreach (var item in wrapped.items)
                {
                    currentRanking += $"{item.rank}�� {item.streak}�A��  {item.name}\n";
                }
                text.text = currentRanking;
                // ""�������Ȃ��ƃ{�^�����������тɃ����L���O���������
                currentRanking = "";

            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
                text.text = "�����L���O�̎擾�Ɏ��s���܂����B\n �Ǘ��҂ɘA�����Ă��������B";
            }
        }
    }

    IEnumerator CallPostAPI(int winStreak, string userName, PostRankingButton prb)
    {
        var jsonPayload = "{\"name\": \"" + userName +"\",\"streak\": \""+ winStreak +"\"}";
        Debug.Log("�o�^���镶����F" + jsonPayload);


        // POST���N�G�X�g�̑��M
        UnityWebRequest postRequest = new UnityWebRequest(postUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
        postRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        postRequest.downloadHandler = new DownloadHandlerBuffer();
        postRequest.SetRequestHeader("Content-Type", "application/json");

        // ���X�|���X��ҋ@
        yield return postRequest.SendWebRequest();

        // �G���[�n���h�����O
        if (postRequest.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + postRequest.error);
            prb.Flag = true;
            prb.DispPushAgain();
        }
        else
        {
            // ���X�|���X�̓��e��\��
            Debug.Log("API Response: " + postRequest.downloadHandler.text);
            // �V�[�����ēǂݍ���
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
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
                // �z�񃉃b�v �� JsonUtility�œǂݍ���
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

    // 2��Ԃ����烉���L���O�X�V�\
    // 1��Ԃ����烉���L���O�X�V�s��
    int CompareScore(int winStreak, BodyItem[] items)
    {
        // �����ꂩ�̃X�R�A��荂����΍X�V�\
        foreach (var body in items)
        {
            if (body.streak < winStreak)
            {
                return 2;
            }
        }

        //�����L���O��9�������Ȃ�ǉ��ł���
        if (items.Length < 9)
        {
            return 2;
        }
        // �ǂ��炩�̏����𖞂����Ȃ���΃����L���O�X�V�s��
        return 1;
    }

    // �����폜���Ă悢
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
    // �����폜���Ă悢
    [Serializable]
    public class LambdaResponse
    {
        public int statusCode;
        public string body;
    }

    // body ���̃A�C�e���\��
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
