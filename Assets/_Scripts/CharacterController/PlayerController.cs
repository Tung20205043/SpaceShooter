using System.Collections;
using UnityEngine;

public class PlayerController : PlaneController {
    #region Instance
    public static PlayerController Instance { get; private set; }
    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion

    private float moveSpeed = 5f;
    private Rigidbody2D rb;
    [SerializeField] private GameObject bullet;
    private bool canShoot = true;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if (GamePlayManager.gameState != GameState.Play) { return; }
        Move();
        if (Input.GetKey(InputManager.Instance.shoot) && canShoot) {
            StartCoroutine(Shooting()); 
        }
        Delegate.cantExitDelegate(transform);
    }

    public override void Move() {
        Vector2 movement = Vector2.zero;
        if (Input.GetKey(InputManager.Instance.upKey)) {
            movement += Vector2.up;
        }
        if (Input.GetKey(InputManager.Instance.downKey)) {
            movement += Vector2.down;
        }
        if (Input.GetKey(InputManager.Instance.rightKey)) {
            movement += Vector2.right;
        }
        if (Input.GetKey(InputManager.Instance.leftKey)) {
            movement += Vector2.left;
        }
        rb.velocity = movement * moveSpeed;
    }
    public override void Shoot() {
        SoundManager.Instance.BulletSound();
        BulletManager.Instance.SpawnObject(bullet, transform.position, Quaternion.identity);
    }
    IEnumerator Shooting() {
        canShoot = false;
        Shoot();
        yield return new WaitForSeconds(0.2f);
        canShoot = true;

    }
    public override void TakeDamage(float dmg) {
        
    }
    public override void Die() {
        Destroy(this.gameObject);
    }

}
