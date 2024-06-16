using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePig : MonoBehaviour
{
    //�N���b�N�����Ƃ��ɁA�n���}�[�������Ă���Δj�󂷂�
    //�����Ă��Ȃ���΃��O���o��
    public GameObject pigObj;
    public GameObject brokenPigObj;

    private void Start()
    {
        //���łɃN���A���Ă���Ȃ�
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
                //�g�����n���}�[������
        }
        else
        {
            MessageManager.instance.ShowMessage("�󂹂�����");
        }
    }
    void Break()
    {
        //���ʂ̃u�^���\��
        pigObj.SetActive(false);
        //��ꂽ�u�^�摜��\��
        brokenPigObj.SetActive(true);
    }

}
