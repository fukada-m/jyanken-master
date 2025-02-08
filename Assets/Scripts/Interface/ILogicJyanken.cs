using UnityEngine;

public interface ILogicJyanken
{
    GameManager.Result Judge(GameManager.Sign myself, GameManager.Sign enemy);
}
