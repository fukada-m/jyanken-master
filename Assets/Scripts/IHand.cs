using UnityEngine;

public interface IHand
{
    string Current { get; }
    void onClickStoneButton();
    void onClickPaperButton();
    void onClickScissorsButton();
    void AddObserver(IObserver observer);
    IObserver GetObserver(int index);
}
