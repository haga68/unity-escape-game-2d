using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //スピーカーの役割
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

    //どこからでも実行できるようにする⇒シングルトン（static）
    public static AudioManager instance;
    private void Awake()
    {
        if(instance == null)//AudioManagerがまだ存在しないなら
        {
            instance = this;
            DontDestroyOnLoad(gameObject);//シーンが変わっても破壊しない
        }
        else
        {
            //すでにAudioManagerがあるなら
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
        audioSourceBGM.clip = bgmList[index] ;//音をセットする
        audioSourceBGM.Play();//再生する
    }
    public void PlaySE(SE se)
    {
        int index = (int)se;
        AudioClip clip = seList[index];
        audioSourceSE.PlayOneShot(clip) ;//一回、鳴らすもの

    }
}
