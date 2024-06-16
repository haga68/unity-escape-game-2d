using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    //�A�C�e���̎�ނ��`
    public enum Item
    {
        Leaf,
        Key,
        Card,
        Hammer,
        Paper,
        Max,
    }

    public Item item;

    //�N������
    private void Start()
    {
        bool hasItem = SaveManager.instance.GetGetItemFlag(item);
        bool usedItem = SaveManager.instance.GetUseItemFlag(item);
        if(usedItem==true) //���Ɏg�p�ς݂Ȃ�
        {
            gameObject.SetActive(false);
        }
        else if(hasItem==true) //���łɎ擾���Ă����
        {
            SetToItemBox(); //�A�C�e���{�b�N�X�ɒǉ�
         }      
    }

    //�N���b�N���ꂽ�Ƃ���
    public void Onthis()
    {
        AudioManager.instance.PlaySE(AudioManager.SE.GetItem);
        SetToItemBox();  //�A�C�e���{�b�N�X�ɒǉ�
        MessageManager.instance.ShowMessage(GetItemName(item) + "����ɓ��ꂽ");
    }
    string GetItemName(Item item)
    {
        switch(item)
        {
            case Item.Leaf:
                return "�t����";
            case Item.Key:
                return "���ɂ̂���";
            case Item.Card:
                return "�G���x�[�^�[�L�[";
            case Item.Hammer:
                return "�n���}�[";
            case Item.Paper:
                return "�ł�����";
        }
        return " ";
    }

    void SetToItemBox()
    {        
        gameObject.SetActive(false);    //�I�u�W�F�N�g��������        
        ItemBox.instance.SetItem(item); //�A�C�e���{�b�N�X�ɒǉ�
    }
}
