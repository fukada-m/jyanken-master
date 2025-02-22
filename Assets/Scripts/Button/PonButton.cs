using UnityEngine;

public class PonButton : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject ponButton;
    IObserver messageText;
    Notify notify;
    ILogicJyanken logicJyanken;
    IEnemyHand enemyHand;
    ISign sign;

    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify = new Notify();
        notify.AddObserver(messageText);
        logicJyanken = new LogicJyanken();
        enemyHand = new EnemyHand();
        sign = new Sign();
    }

    // �e�X�g�p�̈ˑ��֌W�𒍓����郁�\�b�h
    public void Initialize(GameObject h, GameObject p, IObserver m, Notify n, ILogicJyanken l, IEnemyHand e, ISign s)
    {
        handButtons = h;
        ponButton = p;
        messageText = m;
        notify = n;
        logicJyanken = l;
        enemyHand = e;
        sign = s;
    }

    public void OnClickButton()
    {
        handButtons.SetActive(false);
        ponButton.SetActive(false);
        var enemyChoseHand = enemyHand.PickHand();
        var hand = sign.ConvertHandToJapanese(enemyChoseHand);
        notify.SetTextNotify($"�����{hand}��I�т܂���");
        var result = logicJyanken.Judge(Sign.Hand.Scissors, enemyChoseHand);
    }

}
