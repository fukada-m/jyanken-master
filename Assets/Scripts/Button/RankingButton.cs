using UnityEngine;

public class RankingButton : MonoBehaviour
{
    [SerializeField]
    GameObject rankingModal;
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject messageText;
    [SerializeField]
    GetRanking getRanking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // テスト用の依存関係を注入するメソッド
    public void Initialize(GameObject r1,
                           GameObject m1,
                           GameObject m2,
                           GetRanking r2
                           )
    {
        rankingModal = r1;
        menuButtons = m1;
        messageText = m2;
        getRanking = r2;
    }

   public void OnClickButton()
    {
        rankingModal.SetActive(true);
        menuButtons.SetActive(false);
        messageText.SetActive(false);
        getRanking.Get();
    }
}
