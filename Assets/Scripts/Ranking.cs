using UnityEngine;
using TMPro;
using System.Text;
using System.Collections;
using UnityEngine.Networking;

public class Ranking : MonoBehaviour
{
    string getUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Get";
    string currentRanking;

    public void GetRanking(TMP_Text text)
    {
        StartCoroutine(CallGetAPI(text));
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
            text.text = Conversion(currentRanking);
        }
        else
        {
            string responseText = request.downloadHandler.text;

            // JSON���X�|���X���f�V���A���C�Y���ĕ\��
            try
            {
                // ���X�|���X��JSON�̏ꍇ�A�f�V���A���C�Y���ăI�u�W�F�N�g�Ƃ��ď���
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                text.text = jsonResponse.body;
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
                text.text = "�����L���O�̎擾�Ɏ��s���܂����B\n ������x�����L���O�{�^���������Ă��������B";
            }
        }
    }

    string Conversion (string currentRanking)
    {
        string[] parts = currentRanking.Split(',');
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
