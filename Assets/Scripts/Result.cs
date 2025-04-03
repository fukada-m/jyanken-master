using UnityEngine;

public class Result : IResult
{
    public Value.Result Current { get; set; }
    public int WinCount { get; set; } = 0;

    public string ConvertResultToJapanese()
    {
        return Current switch
        {
            Value.Result.Win => "����",
            Value.Result.Lose => "����",
            Value.Result.Draw => "������",
            _ => "�G���["  // �f�t�H���g�P�[�X
        };
    }
}
