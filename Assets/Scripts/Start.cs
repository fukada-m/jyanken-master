using UnityEngine;

public class Start : Notify
{
    public override void GenerateText()
    {
        Text = "何の手を出すか決めてください";
        NotifyObservers();
    }
}
