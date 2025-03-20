using UnityEngine;

public class Result : IResult
{
    public Value.Result Current { get; set; }

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
