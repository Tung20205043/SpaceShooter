using Mono.Cecil.Cil;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] private Button StartButton;
    [SerializeField]  private Button SettingButton;
    [SerializeField] GameObject StartScreen;
    [SerializeField] GameObject SettingScreen;

    public void Awake() {
        StartButton.onClick.AddListener(StartGame);
        SettingButton.onClick.AddListener(Setting);
    }
    void StartGame() {
        SoundManager.Instance.ClickSound();
        GamePlayManager.gameState = GameState.Play;
        StartScreen.SetActive(false);
    }
    void Setting() {
        SoundManager.Instance.ClickSound();
        SettingScreen.SetActive(true);
        StartButton.interactable = false;
        SettingButton.interactable = false;
    }

}
