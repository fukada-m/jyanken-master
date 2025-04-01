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

    // �e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
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
