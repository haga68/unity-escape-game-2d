using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    //�N���b�N�����Ƃ��ɁA���������Ă���΃I�[�v���ɂ���
    //�����Ă��Ȃ���΃��O���o��
    public GameObject openObj;


    private void Start()
    {
        //���łɃN���A���Ă���Ȃ�
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedLocker);
        if (clearGimmick == true)
        {
            Open();
        }
    }


    public void OnThis()
    {
        bool hasKey = ItemBox.instance.CanUseItem(ItemManager.Item.Key);
        if (hasKey == true)
        {
            AudioManager.instance.PlaySE(AudioManager.SE.GimmickClear);
            SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpenedLocker);
            Open();
            ItemBox.instance.UseItem(ItemManager.Item.Key);
        }
        else
        {
            Debug.Log("�����������Ă���");
        }
    }
    void Open()
    {
        //�J���Ă���摜��\��
        openObj.SetActive(true);
    }

}
