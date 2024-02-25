using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        rb.velocity = new Vector2 (0f, speed);
        if (transform.position.y > 5.2f) {
                BulletManager.Instance.DeSpawn(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Enemy") && EnemyController.ready) {
            BulletManager.Instance.DeSpawn(this.gameObject);
        }
    }
}
