using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour
{
    // ���b�Z�[�W�p�l���̕\���A��\���A�e�L�X�g�̕ύX

    //�e�X�g�p
    private void Start()
    {
        ShowMessage("�X�^�W�I���܂�");
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
