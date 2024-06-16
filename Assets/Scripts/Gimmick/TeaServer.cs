using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeaServer : MonoBehaviour
{
    //クリックされたとき
    //タヌキがいれば、動けない
    //タヌキがいなければ、移動（消える）

    public Tanuki tanuki;//たぬきの情報を取得
    Animation anim;
    bool moved = false;

    private void Awake()
    {
        anim = GetComponent<Animation>();
    }

    //すでに動かしているなら消す
    private void Start()
    {
        //すでにクリアしているなら
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTeaServer);
        if (clearGimmick == true)
        {
            Moved();//最初から、その位置に移動させておく
        }
    }
    void Moved()
    {
        moved = true;
        transform.localPosition = new Vector3(-22, -71, 0);
    }
    void Move()
    {
        moved = true;
        anim.Play();
        //    gameObject.SetActive(false);//ティーサーバーが消える
    }

    public void OnThis()
    {
        //すでに移動しているなら、処理をしない
        if(moved==true)
        {
            return;
        }

        bool movedTanuki = tanuki.moved; //たぬきが動いているかどうか
        if (movedTanuki == true)
        {
            AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
            SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTeaServer);
            Move();
        }
        else
        {
            MessageManager.instance.ShowMessage("タヌキがいて動かせない");
        }
    }

}
