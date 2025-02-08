using UnityEngine;

public class PonButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    ILogicJyanken logicJyanken;

    string result;

    void Start()
    {
        logicJyanken = new LogicJyanken(); 
    }
    public void onClickButton()
    {
        handButtons.SetActive(false);
        var result = logicJyanken.Judge(GameManager.Sign.Scissors, GameManager.Sign.Scissors);
    }

    

    
}
