using UnityEngine;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{
    IObserver messageText;
    Notify messageNotify;
    public IResult Result { get; set; }

    void Start()
    {
        messageText = GameObject.Find("MessageText").GetComponent<IObserver>();
        messageNotify = new Notify();
        messageNotify.AddObserver(messageText);
    }
    public void OnClickButton()
    {
        if(Result.Current == Value.Result.Lose)
        {
            SceneManager.LoadScene("JyankenScene");
        }else if (Result.Current == Value.Result.Win)
        {
            messageNotify.SetTextNotify("勝ち逃げはできない!");
        }else if (Result.Current == Value.Result.Draw)
        {
            messageNotify.SetTextNotify("あいこだぞ!\n最後まであきらめるな!");
        }
    }
}
