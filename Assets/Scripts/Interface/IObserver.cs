using TMPro;
using UnityEngine;

public interface IObserver
{
    void Initialize(TMP_Text t);
    // �I�u�U�[�o�[�p�^�[����Update()�̂Ɩ��O���Փ˂��Ă��܂��B
    // TODO: ���O�Փ˂���������
    void Up(Notify notify);

    string GetText();
}
