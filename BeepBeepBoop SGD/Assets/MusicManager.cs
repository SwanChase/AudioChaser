using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    #region Singleton

    public static MusicManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public AudioMixer audioMixer;

    public void SetVolume(string _mixerName, float _segVolume)
    {

    }
}
