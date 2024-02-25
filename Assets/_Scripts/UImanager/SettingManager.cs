using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    public Slider music;
    public AudioSource MusicSound;
    public static float musicValue = 0.5f;
    void Update() {
        musicValue = music.value;
        MusicSound.volume = music.value;
    }
    [SerializeField] private Button StartButton;
    [SerializeField] private Button SettingButton;
    [SerializeField] private Button Xbutton;

    [SerializeField] GameObject SettingScreen;

    public void Awake() {
        Xbutton.onClick.AddListener(DiablePanel);
    }
    void DiablePanel() {
        SoundManager.Instance.ClickSound();
        SettingScreen.SetActive(false);
        StartButton.interactable = true;
        SettingButton.interactable = true;
    }
   
}
