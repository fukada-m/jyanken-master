using UnityEngine;

public interface IHand
{
    Value.Hand Current { get; set; }
    string ConvertHandToJapanese(Value.Hand h);
}
