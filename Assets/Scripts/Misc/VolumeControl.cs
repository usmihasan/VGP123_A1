using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider masterVolume;
    public Toggle mute;
    string masterVolParam = "MasterVol";


    // Start is called before the first frame update
    void Start()
    {
        if (masterVolume)
            masterVolume.onValueChanged.AddListener(HandleSliderChange);

        if (mute)
            mute.onValueChanged.AddListener(HandleToggleChange);
    }

    void HandleSliderChange(float value)
    {
        if (!mute)
            mixer.SetFloat(masterVolParam, value);
        else if (!mute.isOn)
            mixer.SetFloat(masterVolParam, value);
    }

    void HandleToggleChange(bool value)
    {
        if (value)
        {
            mixer.SetFloat(masterVolParam, -80);
        }
        else
        {
            mixer.SetFloat(masterVolParam, masterVolume.value);
        }
    }
}
