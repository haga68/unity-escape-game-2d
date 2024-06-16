using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePig : MonoBehaviour
{
    //クリックしたときに、ハンマーを持っていれば破壊する
    //持っていなければログを出す
    public GameObject pigObj;
    public GameObject brokenPigObj;

    private void Start()
    {
        //すでにクリアしているなら
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.BrokenPig);
        if (clearGimmick == true)
        {
            Break();
        }
    }

    public void OnThis()
    {
        bool hasHammer = ItemBox.instance.CanUseItem(ItemManager.Item.Hammer);
        if (hasHammer == true)
        {
            AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
            SaveManager.instance.SetGimmickFlag(SaveManager.Flag.BrokenPig);
            Break();
            ItemBox.instance.UseItem(ItemManager.Item.Hammer);
                //使ったハンマーを消す
        }
        else
        {
            MessageManager.instance.ShowMessage("壊せそうだ");
        }
    }
    void Break()
    {
        //普通のブタを非表示
        pigObj.SetActive(false);
        //壊れたブタ画像を表示
        brokenPigObj.SetActive(true);
    }

}
