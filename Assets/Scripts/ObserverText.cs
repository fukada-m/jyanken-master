using UnityEngine;
using TMPro;

//�@�v���C���[�̏o��������ώ@���ĕ\����ς���N���X
public class ObserverText : MonoBehaviour, IObserver
{
    [SerializeField]
    TMP_Text text;
    [SerializeField]
    GameManager gameManager;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "����񂯂�}�X�^�[�ւ悤����";
    }

    void TextUpdate(GameManager.Sign sign)
    {
        
        var s = gameManager.ConvertSignToJapanese(sign);

        text.text = $"{s}��I��ł��܂�";
    }

    // �I�u�U�[�o�[�p�^�[����Update()�̂��Ɩ��O���Փ˂��Ă��܂��B
    // TODO: ���O�Փ˂���������
     public void Up(IHand h)
    {
        TextUpdate(h.Current);
    }
}
