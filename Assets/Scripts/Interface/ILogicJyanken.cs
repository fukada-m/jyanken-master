using UnityEngine;

public interface ILogicJyanken
{
    Result.ResultEnum Judge(Sign.Hand myself, Sign.Hand enemy);
}
