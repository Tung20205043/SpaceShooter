using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    public float enemyHp = 5f;
    public float playerHp = 10f;

    public float enemydmg = 1;
    public float playerdmg = 1;

    public float playerScore = 0;
}
