using UnityEngine;

public class Result
{
    public ResultEnum Current { get; set; }
    public enum ResultEnum
    {
        WIn,
        Lose,
        Draw,
        Error
    }
    public string ConvertResultToJapanese(ResultEnum r)
    {
        return r switch
        {
            Result.ResultEnum.WIn => "����",
            Result.ResultEnum.Lose => "����",
            Result.ResultEnum.Draw => "������",
            _ => "�G���["  // �f�t�H���g�P�[�X
        };
    }
}
