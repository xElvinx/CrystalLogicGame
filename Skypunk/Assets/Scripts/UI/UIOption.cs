using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using OneClickLocalization.Core;
//using OneClickLocalization;
//using static UnityEngine.SystemLanguage;

[Serializable]
public class UIOption : MonoBehaviour
{
    [SerializeField] private Text SoundTxt;
    [SerializeField] private Text FXTxt;
    [SerializeField] private Text MusicTxt;

    [SerializeField] private Slider SoundSlider;
    [SerializeField] private Slider FXSlider;
    [SerializeField] private Slider MusicSlider;

    [SerializeField] private AudioMixer audio;

    [SerializeField] private LocalizationSetup localization;

    /*OneClickLocalization.Components.OCLComponentAdapter GetOCL;
    public static OneClickLocalization.OCL.ActiveChanged ChangeLang;
    //.LanguageChanged DefaultLang;
    delegate void ActiveChanged(bool isActive);
    ActiveChanged onActiveChanged;

    public delegate void LanguageChanged(SystemLanguage oldLang, SystemLanguage newLang);
    public event LanguageChanged onLanguageChanged;*/

    private void Awake()
    {
        Debug.Log(Time.time);
    }

    void Update()
    {
        SoundTxt.text = SoundSlider.value.ToString() + "%";
        FXTxt.text = FXSlider.value.ToString() + "%";
        MusicTxt.text = MusicSlider.value.ToString() + "%";

        audio.SetFloat("soundVol", SoundSlider.value - 80);
        audio.SetFloat("musicVol", MusicSlider.value - 80);
        audio.SetFloat("sfxVol", FXSlider.value - 80);
    }

    public void EuLang()
    {
        /*localization.defaultLanguage = SystemLanguage.English;
        localization.SetDefaultLanguage(SystemLanguage.English);*/
        localization.forcedLanguage = SystemLanguage.English;
        //localization.active = false;
        //localization.active = true;
        //onActiveChanged.Invoke(true);
        //ChangeLang.Invoke(false);
        //ChangeLang.Invoke(true);

        //OCL.SetLanguage((SystemLanguage)Enum.Parse(typeof(SystemLanguage), SystemLanguage.English));
        //SetCLanguage((SystemLanguage)Enum.Parse(typeof(SystemLanguage), SystemLanguage.English));
        //if(Application.systemLanguage != SystemLanguage.English)
        //onLanguageChanged.Invoke(SystemLanguage.Russian, SystemLanguage.English);
        //DefaultLang.Invoke(SystemLanguage.Russian, SystemLanguage.English);
    }

    public void RuLang()
    {
        /*localization.defaultLanguage = SystemLanguage.Russian;
        localization.SetDefaultLanguage(SystemLanguage.Russian);*/
        //localization.Ru();
        localization.forcedLanguage = SystemLanguage.Russian;
        //onLanguageChanged.Invoke(SystemLanguage.English, SystemLanguage.Russian);
    }

}
