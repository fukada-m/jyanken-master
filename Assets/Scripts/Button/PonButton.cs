using UnityEngine;

public class PonButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    JyankenResult jyankenResult;
    ILogicJyanken logicJyanken;
    IEnemyHand enemyHand;

    string result;

    void Start()
    {
        logicJyanken = new LogicJyanken(); 
        jyankenResult = new JyankenResult();
        enemyHand = new EnemyHand();

    }
    public void OnClickButton()
    {
        handButtons.SetActive(false);
        var enemyChoseHand = enemyHand.ChoseHand();
        var result = logicJyanken.Judge(GameManager.Sign.Scissors, enemyChoseHand);
        jyankenResult.SetResult(result);
    }

    

    
}
