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
        //すでにクリアしているなら
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedElevator);
        if (clearGimmick == true)
        {
            Opened();
        }
    }

    //カードキーをもっていれば開く
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
            MessageManager.instance.ShowMessage("エレベーターキーが必要だ");
        }
    }
    //既に開いていたら
    void Opened()
    {
        moved = true;
        //左右の扉を消す
        leftObj.SetActive(false);
        rightObj.SetActive(false);
    }

    void Open()
    {
        moved = true;
        anim.Play();
    }

}
