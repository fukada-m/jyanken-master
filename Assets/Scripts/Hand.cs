using UnityEngine;
using System.Collections.Generic;
// �v���C���[���ǂ̎���o���Ă��邩�ɂ��ĐӔC�����N���X

public class Hand :  Notify
{
    // �v���C���[�̎�̏�Ԃ�\��
    public GameManager.Sign Current { get; private set; }

    public void SetCurrent(GameManager.Sign sign)
    {
        Current = sign;
        GenerateText();
        NotifyObservers();
    }

    void GenerateText()
    {
        Text = $"���Ȃ���{Current}��I��ł��܂�";
    }
   
}
