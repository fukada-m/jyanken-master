using UnityEngine;

public class Result : IResult
{
    public Value.Result Current { get; set; }

    public string ConvertResultToJapanese()
    {
        return Current switch
        {
            Value.Result.Win => "勝ち",
            Value.Result.Lose => "負け",
            Value.Result.Draw => "あいこ",
            _ => "エラー"  // デフォルトケース
        };
    }
}
