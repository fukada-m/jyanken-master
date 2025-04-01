using UnityEngine;
using UnityEngine.Networking;
using System.Collections;



public class GetRanking : MonoBehaviour
{
    private string apiUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken";

    void Start()
    {
        
    }

    public void Get()
    {
        StartCoroutine(CallAPI());
    }

    IEnumerator CallAPI()
    {
        // GET���N�G�X�g�̑��M
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);  // GET���N�G�X�g���g��
        request.timeout = 5;
        // ���X�|���X��ҋ@
        yield return request.SendWebRequest();
        Debug.Log("Get ranking request.result: " + request.result);

        // �G���[�n���h�����O
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("API call failed: " + request.error);
        }
        else
        {
            // ���X�|���X�̓��e���擾�������Ǎ��͓��Ɏg���ĂȂ�
            string responseText = request.downloadHandler.text;

            // JSON���X�|���X���f�V���A���C�Y���ĕ\��
            try
            {
                // ���X�|���X��JSON�̏ꍇ�A�f�V���A���C�Y���ăI�u�W�F�N�g�Ƃ��ď���
                LambdaResponse jsonResponse = JsonUtility.FromJson<LambdaResponse>(responseText);
                Debug.Log("Lambda Response Body: " + jsonResponse.body);  // ������body�̓��e��\��
            }
            catch (System.Exception ex)
            {
                Debug.LogError("Error parsing JSON response: " + ex.Message);
            }
        }

    }
}

// Lambda�̃��X�|���X�\���ɍ��킹���N���X
[System.Serializable]
public class LambdaResponse
{
    public int statusCode;
    public string body;
}
