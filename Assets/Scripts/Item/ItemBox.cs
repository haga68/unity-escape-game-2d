using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject[] boxes;

    //アイテムボックスをどこからでも使えるように　
    public static  ItemBox instance;    //static化

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;    //自身（ItemBox）を代入して、どこでも使えるようにする
        }
    }

    private void Start()
    {
        //すべてのボックスを空にする
        for(int i = 0; i < boxes.Length; i++)
        {
            boxes[i].SetActive(false);
        }
        /*
         ロードしてもうまく反映されない場合。（100番参照）
        原因はItem.csのStart関数よりもItemBox.csのStart関数の方が
        後に実行されること。（ロードしても非表示にしてしまう）

        プロジェクト設定のスクリプト実行順序より
        ItemBox.csをItem.csよりも先に実行されるように修正。         
         */

        //セーブデータがあると表示する
        //セーブデータを取得する
    }

    //アイテムを取得
    public void SetItem(ItemManager.Item item)
    {
        int index = (int)item;
        boxes[index].SetActive(true);
        SaveManager.instance.SetGetItemFlag(item);
    }

    //アイテムが使えるかどうか
    public bool CanUseItem(ItemManager.Item item)
    {
        int index = (int)item;
        if (boxes[index].activeSelf ==true)//画像が存在すれば
        {
            return true;
        }
        return false;    
    }

    //アイテムを使用
    public void UseItem(ItemManager.Item item)
    {
        int index = (int)item;
        boxes[index].SetActive(false);//アイテムを使用したら消す
        SaveManager.instance.SetUseItemFlag(item);
    }

}
