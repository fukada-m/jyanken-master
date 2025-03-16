using UnityEngine;
using TMPro;

//�@�v���C���[�̏o��������ώ@���ĕ\����ς���N���X
public class ObserverText : MonoBehaviour, IObserver
{
    [SerializeField]
    TMP_Text _text;
    [SerializeField]
    string firstText;

    // �e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(TMP_Text t)
    {
        _text = t;
    }

     public void Up(Notify n)
    {
        TextUpdate(n.Text);
    }

    // �e�X�g�Ńe�L�X�g�̓��e���擾����̂ɗp����
    public string GetText()
    {
        return _text.text;
    }

    //Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _text.text = firstText;
    }

    void TextUpdate(string t)
    {
        _text.text = t;
    }


}
