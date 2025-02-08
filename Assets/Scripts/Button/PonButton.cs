using UnityEngine;

public class PonButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    JyankenResult jyankenResult;
    ILogicJyanken logicJyanken;

    string result;

    void Start()
    {
        logicJyanken = new LogicJyanken(); 
        jyankenResult = new JyankenResult();

    }
    public void onClickButton()
    {
        handButtons.SetActive(false);
        var result = logicJyanken.Judge(GameManager.Sign.Scissors, GameManager.Sign.Scissors);
        jyankenResult.Result = result;
    }

    

    
}
