using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    //どこからでも使えるように　
    public static SaveManager instance;    //static化
    private void Awake()
    {
        instance = this;
        Load();
        //Loadを、ItemManagerのスタート関数より早く実行させるため
        //Start()より早く実行されるAwake()で実行
    }
    
    //ギミックのフラグ列挙
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

    // saveDataをJson(文字列)化
    //PlayerPrefsで文字列を保存
    void Save()
    {
        string json = JsonUtility.ToJson(saveData);
        PlayerPrefs.SetString(SAVE_KEY , json);
    }

    //PlayerPrefsでjson文字列を取得
    //json文字列をクラスに変換
    public void Load()
    {
        saveData = new SaveData();
        if(PlayerPrefs.HasKey(SAVE_KEY)==true) //初期データがあるならロードする
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

    //フラグ（アイテム取得）
    public void SetGetItemFlag(ItemManager.Item item)
    {
        int index = (int)item;                      //取得したアイテムに応じて、数字に変換
        saveData.getItems[index] = true;  //その番号の配列をtrueにする
        Save();
    }
    //特定のフラグを取得する
    public bool GetGetItemFlag(ItemManager.Item item)
    {
        int index = (int)item;
        return saveData.getItems[index];
        //あるアイテム（Leafとか）を取得していたらtrueを返し、
        //未取得であれば、falseを返す
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
public class SaveData //何を取得したか
{
    public bool[] getItems = new bool[(int)ItemManager.Item.Max]; //取得したアイテム
    public bool[] useItems = new bool[(int)ItemManager.Item.Max]; //使用したアイテム
    public bool[] gimmick = new bool[(int)SaveManager.Flag.Max];
}
