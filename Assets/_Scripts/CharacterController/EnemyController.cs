using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PlaneController {
    public static bool ready { get; private set; } = false;
    private float orinalHp;

    private void Update() {
        if (GamePlayManager.gameState != GameState.Play) { return; }


        if (EnemyManager.currentShape == EnemyShape.Ready) {
            ready = true;
        }
    }
    private void Start() {
        orinalHp = GameManager.Instance.enemyHp;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (!ready) { return; }
        if (other.CompareTag("PlayerBullet")) {
            TakeDamage(GameManager.Instance.playerdmg);
        }
    }
    public override void Move() { }
    public override void Shoot() {

    }
    public override void TakeDamage(float dmg) {
        orinalHp -= dmg;
        
        if (orinalHp <= 0) {
            Die();
        }
    }
    public override void Die() {
        SoundManager.Instance.DeathSound();
        GameManager.Instance.playerScore += 1;
        GamePlayManager.Instance.hasPoint = true;
        Destroy(gameObject);

    }
    //public void PlusPoint() {
    //    GameManager.Instance.playerScore += 1;
    //    SoundManager.Instance.PointSound();
    //}
}
