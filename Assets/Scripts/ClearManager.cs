using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour
{
    void Start()
    {
        AudioManager.instance.PlayBGM(AudioManager.BGM.Clear);
    }


}
