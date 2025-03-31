using UnityEngine;

public class RankingButton : MonoBehaviour
{
    [SerializeField]
    GameObject rankingModal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // テスト用の依存関係を注入するメソッド
    public void Initialize(GameObject r)
    {
        rankingModal = r;
    }

   public void OnClickButton()
    {
        rankingModal.SetActive(true);
    }
}
