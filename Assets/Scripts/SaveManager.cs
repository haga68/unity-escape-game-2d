using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //�ǂ�����ł��g����悤�Ɂ@
    public static SaveManager instance;    //static��
    private void Awake()
    {
        instance = this;
        Load();
        //Load���AItemManager�̃X�^�[�g�֐���葁�����s�����邽��
        //Start()��葁�����s�����Awake()�Ŏ��s
    }
    
    //�M�~�b�N�̃t���O��
    public enum Flag
    {
        OpenedLocker01,
        MovedTanuki,
        MovedTeaServer,
        OpenedLocker,
        BrokenPig,
        OpenedFireHydrant,
        OpenedElevator,
        Max,
    }

    const string SAVE_KEY = "SaveData";
    public SaveData saveData;

    //private void Start()
    //{
    //    Debug.Log("SaveManager");
    //}

    // saveData��Json(������)��
    //PlayerPrefs�ŕ������ۑ�
    void Save()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SAVE_KEY , json);
    }

    //PlayerPrefs��json��������擾
    //json��������N���X�ɕϊ�
    public void Load()
    {
        saveData = new SaveData();
        if(PlayerPrefs.HasKey(SAVE_KEY)==true) //�����f�[�^������Ȃ烍�[�h����
        {
            string json = PlayerPrefs.GetString(SAVE_KEY);
            saveData = JsonUtility.FromJson<SaveData>(json);
        }
    }
    public void CreateNewData()
    {
        PlayerPrefs.DeleteKey(SAVE_KEY);
        saveData = new SaveData();
    }

    public bool HasSaveData()
    {
        return PlayerPrefs.HasKey(SAVE_KEY);
    }

    //�t���O�i�A�C�e���擾�j
    public void SetGetItemFlag(ItemManager.Item item)
    {
        int index = (int)item;                      //�擾�����A�C�e���ɉ����āA�����ɕϊ�
        saveData.getItems[index] = true;  //���̔ԍ��̔z���true�ɂ���
        Save();
    }
    //����̃t���O���擾����
    public bool GetGetItemFlag(ItemManager.Item item)
    {
        int index = (int)item;
        return saveData.getItems[index];
        //����A�C�e���iLeaf�Ƃ��j���擾���Ă�����true��Ԃ��A
        //���擾�ł���΁Afalse��Ԃ�
    }

    public void SetUseItemFlag(ItemManager.Item item)
    {
        int index = (int)item;  
        saveData.useItems[index] = true; 
        Save();
    }
    public bool GetUseItemFlag(ItemManager.Item item)
    {
        int index = (int)item;
        return saveData.useItems[index];
    }

    public void SetGimmickFlag(Flag flag)
    {
        int index = (int)flag;          
        saveData.gimmick[index] = true;
        Save();
    }
    
    public bool GetGimmickFlag(Flag flag)
    {
        int index = (int)flag;
        return saveData.gimmick[index];
    }
}

[Serializable]
public class SaveData //�����擾������
{
    public bool[] getItems = new bool[(int)ItemManager.Item.Max]; //�擾�����A�C�e��
    public bool[] useItems = new bool[(int)ItemManager.Item.Max]; //�g�p�����A�C�e��
    public bool[] gimmick = new bool[(int)SaveManager.Flag.Max];
}
