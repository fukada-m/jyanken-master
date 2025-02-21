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
            Result.ResultEnum.WIn => "勝ち",
            Result.ResultEnum.Lose => "負け",
            Result.ResultEnum.Draw => "あいこ",
            _ => "エラー"  // デフォルトケース
        };
    }
}
