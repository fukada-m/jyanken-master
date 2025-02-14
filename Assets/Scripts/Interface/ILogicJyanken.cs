using UnityEngine;

public interface ILogicJyanken
{
    GameManager.Result Judge(Sign.Hand myself, Sign.Hand enemy);
}
