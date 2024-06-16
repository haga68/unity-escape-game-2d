using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public GameObject[] boxes;

    //�A�C�e���{�b�N�X���ǂ�����ł��g����悤�Ɂ@
    public static  ItemBox instance;    //static��

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;    //���g�iItemBox�j�������āA�ǂ��ł��g����悤�ɂ���
        }
    }

    private void Start()
    {
        //���ׂẴ{�b�N�X����ɂ���
        for(int i = 0; i < boxes.Length; i++)
        {
            boxes[i].SetActive(false);
        }
        /*
         ���[�h���Ă����܂����f����Ȃ��ꍇ�B�i100�ԎQ�Ɓj
        ������Item.cs��Start�֐�����ItemBox.cs��Start�֐��̕���
        ��Ɏ��s����邱�ƁB�i���[�h���Ă���\���ɂ��Ă��܂��j

        �v���W�F�N�g�ݒ�̃X�N���v�g���s�������
        ItemBox.cs��Item.cs������Ɏ��s�����悤�ɏC���B         
         */

        //�Z�[�u�f�[�^������ƕ\������
        //�Z�[�u�f�[�^���擾����
    }

    //�A�C�e�����擾
    public void SetItem(ItemManager.Item item)
    {
        int index = (int)item;
        boxes[index].SetActive(true);
        SaveManager.instance.SetGetItemFlag(item);
    }

    //�A�C�e�����g���邩�ǂ���
    public bool CanUseItem(ItemManager.Item item)
    {
        int index = (int)item;
        if (boxes[index].activeSelf ==true)//�摜�����݂����
        {
            return true;
        }
        return false;    
    }

    //�A�C�e�����g�p
    public void UseItem(ItemManager.Item item)
    {
        int index = (int)item;
        boxes[index].SetActive(false);//�A�C�e�����g�p���������
        SaveManager.instance.SetUseItemFlag(item);
    }

}
