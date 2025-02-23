using UnityEngine;

public interface ILogicJyanken
{
    Value.Result Judge(Value.Hand myself, Value.Hand enemy);
}
