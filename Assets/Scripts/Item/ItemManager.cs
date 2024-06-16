using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //アイテムの種類を定義
    public enum Item
    {
        Leaf,
        Key,
        Card,
        Hammer,
        Paper,
        Max,
    }

    public Item item;

    //起動時に
    private void Start()
    {
        bool hasItem = SaveManager.instance.GetGetItemFlag(item);
        bool usedItem = SaveManager.instance.GetUseItemFlag(item);
        if(usedItem==true) //既に使用済みなら
        {
            gameObject.SetActive(false);
        }
        else if(hasItem==true) //すでに取得していれば
        {
            SetToItemBox(); //アイテムボックスに追加
         }      
    }

    //クリックされたときに
    public void Onthis()
    {
        AudioManager.instance.PlaySE(AudioManager.SE.GetItem);
        SetToItemBox();  //アイテムボックスに追加
        MessageManager.instance.ShowMessage(GetItemName(item) + "を手に入れた");
    }
    string GetItemName(Item item)
    {
        switch(item)
        {
            case Item.Leaf:
                return "葉っぱ";
            case Item.Key:
                return "金庫のかぎ";
            case Item.Card:
                return "エレベーターキー";
            case Item.Hammer:
                return "ハンマー";
            case Item.Paper:
                return "焦げた紙";
        }
        return " ";
    }

    void SetToItemBox()
    {        
        gameObject.SetActive(false);    //オブジェクトを消して        
        ItemBox.instance.SetItem(item); //アイテムボックスに追加
    }
}
