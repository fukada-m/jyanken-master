using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PostRankingButton : MonoBehaviour
{
    string apiUrl = "https://s8fwnpqtcb.execute-api.ap-northeast-1.amazonaws.com/jyanken/Post";
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
        // ���M����f�[�^
        string jsonPayload = "{\"ranking\": \"1��,4�A��,�ς��ς�\"}";

        // POST���N�G�X�g�̑��M
        UnityWebRequest request = new UnityWebRequest(apiUrl, "POST");
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
}
