using UnityEngine;

public class Result : IResult
{
    public Value.Result Current { get; set; }

    public string ConvertResultToJapanese(Value.Result r)
    {
        return r switch
        {
            Value.Result.WIn => "勝ち",
            Value.Result.Lose => "負け",
            Value.Result.Draw => "あいこ",
            _ => "エラー"  // デフォルトケース
        };
    }
}
