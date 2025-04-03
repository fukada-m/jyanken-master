using TMPro;
using UnityEngine;

public class DispRankingButton : MonoBehaviour
{
    [SerializeField]
    GameObject rankingModal;
    [SerializeField]
    GameObject menuButtons;
    [SerializeField]
    GameObject messageText;
    [SerializeField]
    Ranking ranking;
    [SerializeField]
    TMP_Text rankingText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rankingText.text = "ランキングを取得中...";
    }

    // テスト用の依存関係を注入するメソッド
    public void Initialize(GameObject r1,
                           GameObject m1,
                           GameObject m2,
                           Ranking r2
                           )
    {
        rankingModal = r1;
        menuButtons = m1;
        messageText = m2;
        ranking = r2;
    }

    public void OnClickButton()
    {
        rankingModal.SetActive(true);
        menuButtons.SetActive(false);
        messageText.SetActive(false);
        ranking.GetRanking(rankingText);
    }
}

