using UnityEngine;
using System.Collections;

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
    IResult result;
    public virtual IHand Hand {  get; set; }

    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        notify = new Notify();
        notify.AddObserver(messageText);
        logicJyanken = new LogicJyanken();
        enemyHand = new EnemyHand();
        result = new Result();
    }

    // テスト用の依存関係を注入するメソッド
    public void Initialize(
        GameObject h1, 
        GameObject p, 
        Notify n, 
        ILogicJyanken l, 
        IEnemyHand e, 
        IHand h2, 
        IResult r
    )
    {
        handButtons = h1;
        ponButton = p;
        notify = n;
        logicJyanken = l;
        enemyHand = e;
        Hand = h2;
        result = r;
    }

    public void OnClickButton()
    {
        handButtons.SetActive(false);
        var enemyChoseHand = enemyHand.PickHand();
        var hand = Hand.ConvertHandToJapanese(enemyChoseHand);
        notify.SetTextNotify($"相手は{hand}を選びました");
        result.Current = logicJyanken.Judge(Hand.Current, enemyChoseHand);
        StartCoroutine(DispResult());
        //ponButton.SetActive(false);
    }

    // コルーチンのテスト用
    public void TestDispResult()
    {
        StartCoroutine(DispResult());
    }

    IEnumerator DispResult()
    {
        yield return new WaitForSeconds(1f);
        notify.SetTextNotify($"あなたの{result.ConvertResultToJapanese(result.Current)}");
        Debug.Log("これでコルーチン終わり");
    }
}
