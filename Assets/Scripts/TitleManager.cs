using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public GameObject continueButton;
    private void Start()
    {
        AudioManager.instance.PlayBGM(AudioManager.BGM.Title);
        //�Z�[�u�f�[�^���Ȃ���΁A�u��������v�{�^����\�����Ȃ�
        bool hasSaveData = SaveManager.instance.HasSaveData();
        if(hasSaveData ==true)
        {            
            continueButton.SetActive(true);//�u��������v�{�^����\��
        }
        else
        {
            continueButton.SetActive(false);
        }
    }

    public void OnStartButton()
    {
        AudioManager.instance.PlaySE(AudioManager.SE.OnButton);
        //�f�[�^�������ĐV�K�쐬
        SaveManager.instance.CreateNewData();
        SceneManager.LoadScene("Main");
    }
    public void OnContinueButton() 
    {
        //�f�[�^�����[�h����
        SaveManager.instance.Load();
        SceneManager.LoadScene("Main");
    }

}
