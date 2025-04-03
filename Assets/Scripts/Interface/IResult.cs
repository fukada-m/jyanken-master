using UnityEngine;

public interface IResult
{
    Value.Result Current { get; set; }
    int WinCount { get; set; }

    string ConvertResultToJapanese();
}
