using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHydrant : MonoBehaviour
{
    public GameObject openObj;

    //連続入力の実装
    enum Direction
    {
        Left = 0,
        Right = 1
    }

    //Playerの入力
    List<Direction> userInputs = new List<Direction>();

    //正解の連続入力（右、左、左、右、右）
    Direction[] correctAnswer =
    {
        Direction.Right,
        Direction.Left,
        Direction.Left,
        Direction.Right,
        Direction.Right,
    };

    private void Start()
    {
        //すでにクリアしているなら
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedFireHydrant);
        if (clearGimmick == true)
        {
            openObj.SetActive(true);
        }
    }

    //入力
    public void OnButton(int type)
    {
        //type:0　左
        //type:1　右
        if(type == 0)
        {
            userInputs.Add(Direction.Left);
        }
        if (type == 1)
        {
            userInputs.Add(Direction.Right);
        }
        Debug.Log(type);
        //ユーザーの入力を代入
        //5回入力されたらチェックする
        if(userInputs.Count == 5)
        {
            if(IsAllClear() == true)
            {
                Clear();
            }
            else
            {
                //不一致の場合の実装 リセット
                ResetInput();
            }
        }
    }
    void ResetInput()
    {
        MessageManager.instance.ShowMessage("入力が間違っているようだ");
        userInputs.Clear();
        Debug.Log("リセット");
    }

    //一致しているかチェック
    bool IsAllClear()
    {
        for (int i = 0; i < userInputs.Count; i++)
        {
            if (userInputs[i] != correctAnswer[i])
            {
                return false;
            }
        }
        return true;
    }
    void Clear()
    {
        AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
        Debug.Log("クリア");
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpenedFireHydrant);
        openObj.SetActive(true);
        ItemBox.instance.UseItem(ItemManager.Item.Paper);   //紙を消す（自分で付け足し）
    }
}
