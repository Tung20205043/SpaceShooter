using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayManager : MonoBehaviour
{
    #region Singleton
    public static GamePlayManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    public static GameState gameState;
    private void Start() {
        gameState = GameState.Start;
    }
    [SerializeField] private TextMeshProUGUI currentPoint;
    [SerializeField] private GameObject plusPoint;
    [SerializeField] private GameObject winPanel;
    public bool hasPoint;
    private void Update() {
        if (gameState != GameState.Play) { return; }
        currentPoint.text = "Score: " + GameManager.Instance.playerScore;
        if (hasPoint) {
            StartCoroutine(PlusPoint());
        }
        if (GameManager.Instance.playerScore == 16) { 
            StartCoroutine(EndGame());
            gameState = GameState.End;
        }
    }
    IEnumerator PlusPoint() {
        SoundManager.Instance.PointSound();
        plusPoint.SetActive(true);
        hasPoint = false;
        yield return new WaitForSeconds(0.5f);
        plusPoint.SetActive(false);        
    }
    IEnumerator EndGame() {
        yield return new WaitForSeconds(0.5f);
        winPanel.SetActive(true);
    }
}
