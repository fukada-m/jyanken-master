using UnityEngine;

public class Start : Notify
{
    public override void GenerateText()
    {
        Text = "���̎���o�������߂Ă�������";
        NotifyObservers();
    }
}
