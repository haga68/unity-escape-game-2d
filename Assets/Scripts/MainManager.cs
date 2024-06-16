using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlayBGM(AudioManager.BGM.Main);
    }

}
