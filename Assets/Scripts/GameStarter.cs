using UnityEngine;
/* 
 * 最初の準備でやること 
 * - 使わないボタンの非表示
 * - オブザーバーのセット
 */

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    GameObject handButtons;
    [SerializeField]
    GameObject settingModal;
    [SerializeField]
    GameObject ponButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideObject();
        SetObserver();
    }
    void HideObject()
    {
        handButtons.SetActive(false);
        settingModal.SetActive(false);
        ponButton.SetActive(false);
    }
    void SetObserver()
    {

    }
}
