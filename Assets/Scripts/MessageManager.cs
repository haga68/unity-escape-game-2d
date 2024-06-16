using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    // メッセージパネルの表示、非表示、テキストの変更

    //テスト用
    private void Start()
    {
        ShowMessage("スタジオしまず");
    }

    public GameObject panel;
    public Text message;

    public static MessageManager instance;
    private void Awake()
    {
            instance = this;
    }


    void ShowPanel()
    {
        panel.SetActive(true);
    }
    public void HidePanel()
    {
        panel.SetActive(false);
    }
    public void ShowMessage(string msg)
    {
        message.text = msg;
        ShowPanel();
    }

}
