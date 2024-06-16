using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject leftObj;
    public GameObject rightObj;
    Animation anim;
    bool moved = false;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }
    private void Start()
    {
        //���łɃN���A���Ă���Ȃ�
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedElevator);
        if (clearGimmick == true)
        {
            Opened();
        }
    }

    //�J�[�h�L�[�������Ă���ΊJ��
    public void OnThis()
    {
        if(moved==true)
        {
            return;
        }
        bool hasCard = ItemBox.instance.CanUseItem(ItemManager.Item.Card);
        if(hasCard == true)
        {
            AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
            SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpenedElevator);
            Open();
            ItemBox.instance.UseItem(ItemManager.Item.Card);
        }
        else
        {
            MessageManager.instance.ShowMessage("�G���x�[�^�[�L�[���K�v��");
        }
    }
    //���ɊJ���Ă�����
    void Opened()
    {
        moved = true;
        //���E�̔�������
        leftObj.SetActive(false);
        rightObj.SetActive(false);
    }

    void Open()
    {
        moved = true;
        anim.Play();
    }

}
