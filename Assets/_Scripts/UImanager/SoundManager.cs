using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    [SerializeField] private AudioSource pointSound;
    [SerializeField] private AudioSource bulletSound;
    [SerializeField] private AudioSource deathSound;
    [SerializeField] private AudioSource clickSound;

    public void PointSound() { 
        pointSound.Play();
    }
    public void BulletSound() {
        bulletSound.Play();
    }
    public void DeathSound() {
        deathSound.Play();
    }
    public void ClickSound() {

        clickSound.Play();
    }
}
