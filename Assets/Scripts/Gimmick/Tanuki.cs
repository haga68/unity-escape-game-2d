using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanuki : MonoBehaviour
{
    public bool moved = false;

    private void Start()
    {
        //���łɃN���A���Ă���Ȃ�
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.MovedTanuki);
        if (clearGimmick == true)
        {
            Move();
        }
    }

    //�N���b�N���ꂽ�Ƃ��ɁA�t���ς������Ă���Ώ�����
    public void OnThis()
    {
        bool hasLeaf = ItemBox.instance.CanUseItem(ItemManager.Item.Leaf); //�A�C�e��Box�̎����A�A�C�e����
        if(hasLeaf == true)     //�t���ς������Ă����
        {
            AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
            Move();
            MessageManager.instance.ShowMessage("���ʂ��͏����Ă��܂���");
            ItemBox.instance.UseItem(ItemManager.Item.Leaf);//�t���ς��g�p
        }
        else
        {
            MessageManager.instance.ShowMessage("�t���ς�����΁E�E�E");
        }
    }

    void Move()
    {
        moved = true;
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.MovedTanuki);
        gameObject.SetActive(false);                //�K������
    }
}
