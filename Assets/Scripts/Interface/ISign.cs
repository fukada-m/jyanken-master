using UnityEngine;

public interface ISign
{
    Sign.Hand Current { get; set; }
    string ConvertHandToJapanese(Sign.Hand h);
}
