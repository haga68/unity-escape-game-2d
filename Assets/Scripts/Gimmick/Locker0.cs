using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker0 : MonoBehaviour
{
    //�_�C�A�����N���A������A���b�J�[���I�[�v���ɂ���
    public GameObject openObj;

    private void Start()
    {
        //���łɃN���A���Ă���Ȃ�
        bool clearGimmick = SaveManager.instance.GetGimmickFlag(SaveManager.Flag.OpenedLocker01);
        if(clearGimmick == true)
        {
            Open();
        }
    }

    public void Open()
    {
        openObj.SetActive(true);
        SaveManager.instance.SetGimmickFlag(SaveManager.Flag.OpenedLocker01);
    }

}
