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
        // GET���N�G�X�g�̑��M
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);  // GET���N�G�X�g���g��
        request.timeout = 10;
        // ���X�|���X��ҋ@
        yield return request.SendWebRequest();
        Debug.Log("Get ranking request.result: " + request.result);

        // �G���[�n���h�����O
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + request.error);
            rankingText.text = "�����L���O�̎擾�Ɏ��s���܂����B\n ������x�����L���O�{�^���������Ă��������B";
        }
        else
        {
            string responseText = request.downloadHandler.text;

            // JSON���X�|���X���f�V���A���C�Y���ĕ\��
            try
            {
                // ���X�|���X��JSON�̏ꍇ�A�f�V���A���C�Y���ăI�u�W�F�N�g�Ƃ��ď���
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                result = jsonResponse.body;
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
                rankingText.text = "�����L���O�̎擾�Ɏ��s���܂����B\n ������x�����L���O�{�^���������Ă��������B";
            }
        }
        result = Conversion(result);
        rankingText.text = result;
    }
    // ,���X�y�[�X�ɕϊ����� 3���ɉ��s����
    string Conversion(string body)
    {
        string[] parts = body.Split(',');
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < parts.Length; i += 3)
        {
            // ���S�m�F�i�v�f����3�̔{���łȂ��ꍇ�ɂ��Ή��j
            if (i + 2 < parts.Length)
            {
                sb.AppendLine($"{parts[i]} {parts[i + 1]} {parts[i + 2]}");
            }
        }
        string result = sb.ToString();
        return result;
    }
}

// Lambda�̃��X�|���X�\���ɍ��킹���N���X
[System.Serializable]
public class LambdaResponse
{
    public int statusCode;
    public string body;
}
