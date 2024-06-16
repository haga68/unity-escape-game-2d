using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
    public bool moved = false;

    private void Start()
    {
        //すでにクリアしているなら
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTanuki);
        if (clearGimmick == true)
        {
            Move();
        }
    }

    //クリックされたときに、葉っぱをもっていれば消える
    public void OnThis()
    {
        bool hasLeaf = ItemBox.instance.CanUseItem(ItemManager.Item.Leaf); //アイテムBoxの実装、アイテムの
        if(hasLeaf == true)     //葉っぱをもっていれば
        {
            AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
            Move();
            MessageManager.instance.ShowMessage("たぬきは消えてしまった");
            ItemBox.instance.UseItem(ItemManager.Item.Leaf);//葉っぱを使用
        }
        else
        {
            MessageManager.instance.ShowMessage("葉っぱがあれば・・・");
        }
    }

    void Move()
    {
        moved = true;
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTanuki);
        gameObject.SetActive(false);                //狸を消す
    }
}
