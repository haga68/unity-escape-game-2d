using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialLocker : MonoBehaviour
{
    //三つのボタンをそれぞれクリックして絵柄がすべて一致すればクリア

    //ボタンの画像を取得
    public Image[] buttons;
    //表示するマークを列挙
    enum Mark
    {
        Maru,
        Sankaku,
        Hoshi,
        Daia
    }
    //現在のマーク
    Mark[] currentMarks = { Mark.Maru, Mark.Maru, Mark.Maru };
    Mark[] correctAnswerMarks = { Mark.Maru, Mark.Sankaku, Mark.Hoshi };

    //表示する画像の素材一覧
    public Sprite[] resourceSprites;
    //(外部の関数を設定したい場合)UnityEventを使う
    public UnityEvent ClearEvent;

    public void OnMarkButton(int position) //ボタンをクリックしたら
    {        
        ChangeMark(position);           //（positionの）マークを変更して
        ShowMark(position);             //画像を表示

        //クリアするかどうかチェック
        if(IsAllClearMark() == true) //全部、一致していたら
        {
            Clear();                            //クリア
        }
    }
    void ChangeMark(int position)
    {
        currentMarks[position]++; //一つ次のマークに
        if (currentMarks[position] > Mark.Daia) 
        {
            currentMarks[position] = Mark.Maru;
        }
    }

    void ShowMark(int position)
    {
        int index = (int)currentMarks[position]; //int化
        buttons[position].sprite = resourceSprites[index]; //対応する画像を表示
    }

    //全部、一致しているかどうか
    bool IsAllClearMark()
    {
        for (int i = 0;i < currentMarks.Length; i++)
        {
            if (currentMarks[i] != correctAnswerMarks[i])
            {                
                return false;   //一つでも違うものがあればfalse
            }
        }
        return true; //すべて一致していたらクリア
    }
    void Clear()
    {
        AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
        MessageManager.instance.ShowMessage("ロッカーが開いた");
        ClearEvent.Invoke();    //UnityEventを発動
    }  
}
