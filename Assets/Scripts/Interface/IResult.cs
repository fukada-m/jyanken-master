using UnityEngine;

public interface IResult
{
    Value.Result Current { get; set; }

    string ConvertResultToJapanese(Value.Result r);
}
