using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //�X�s�[�J�[�̖���
    public AudioSource audioSourceBGM;
    public AudioSource audioSourceSE;

    public AudioClip[] bgmList;
    public enum BGM
    {
        Title,
        Main,
        Clear
    };

    public AudioClip[] seList;
    public enum SE
    {
        OnButton,
        GimmickClear,
        GetItem
    };

    //�ǂ�����ł����s�ł���悤�ɂ���˃V���O���g���istatic�j
    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)//AudioManager���܂����݂��Ȃ��Ȃ�
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//�V�[�����ς���Ă��j�󂵂Ȃ�
        }
        else
        {
            //���ł�AudioManager������Ȃ�
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBGM(BGM.Title);
    }

    public void PlayBGM(BGM bgm)
    {
        int index = (int)bgm;
        audioSourceBGM.clip = bgmList[index] ;//�����Z�b�g����
        audioSourceBGM.Play();//�Đ�����
    }
    public void PlaySE(SE se)
    {
        int index = (int)se;
        AudioClip clip = seList[index];
        audioSourceSE.PlayOneShot(clip) ;//���A�炷����

    }
}
