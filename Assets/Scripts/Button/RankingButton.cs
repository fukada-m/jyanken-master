using UnityEngine;

public class RankingButton : MonoBehaviour
{
    [SerializeField]
    GameObject rankingModal;
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject messageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // テスト用の依存関係を注入するメソッド
    public void Initialize(GameObject r,
                           GameObject m1, 
                           GameObject m2
                           )
    {
        rankingModal = r;
        menuButtons = m1;
        messageText = m2;
    }

   public void OnClickButton()
    {
        rankingModal.SetActive(true);
        menuButtons.SetActive(false);
        messageText.SetActive(false);
    }
}
