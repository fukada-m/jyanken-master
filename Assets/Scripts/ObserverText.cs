using UnityEngine;
using TMPro;

//�@�v���C���[�̏o��������ώ@���ĕ\����ς���N���X
public class ObserverText : MonoBehaviour, IObserver
{
    [SerializeField] TMP_Text text;

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "�o��������߂Ă�������";
    }

    void TextUpdate(GameManager.Sign sign)
    {
        string s = sign switch
        {
            GameManager.Sign.Stone => "�O�[",
            GameManager.Sign.Scissors => "�`���L",
            GameManager.Sign.Paper => "�p�[",
            _ => "�G���[" // �f�t�H���g�P�[�X
        };

        text.text = $"{s}��I��ł��܂�";
    }

    // �I�u�U�[�o�[�p�^�[����Update()�̂��Ɩ��O���Փ˂��Ă��܂��B
    // TODO: ���O�Փ˂���������
     public void Up(IHand h)
    {
        TextUpdate(h.Current);
    }
}
