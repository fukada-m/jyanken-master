using UnityEngine;

public class RankingButton : MonoBehaviour
{
    [SerializeField]
    GameObject rankingModal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // �e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(GameObject r)
    {
        rankingModal = r;
    }

   public void OnClickButton()
    {
        rankingModal.SetActive(true);
    }
}
