using UnityEngine;

public class Result : IResult
{
    public Value.Result Current { get; set; }

    public string ConvertResultToJapanese(Value.Result r)
    {
        return r switch
        {
            Value.Result.WIn => "����",
            Value.Result.Lose => "����",
            Value.Result.Draw => "������",
            _ => "�G���["  // �f�t�H���g�P�[�X
        };
    }
}
