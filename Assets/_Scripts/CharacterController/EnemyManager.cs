using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyManager : MonoBehaviour {
    [SerializeField] GameObject[] enemy;
    public Tilemap tilemap;
    public Vector3Int[] targetGridCells;
    public float moveSpeed = 2f;
    private bool changeShape = true;

    public static EnemyShape currentShape = EnemyShape.Square;
    private void Start() {
        DrawSquare();

    }

    private void Update() {
        if (GamePlayManager.gameState != GameState.Play) { return; }

        if (EnemyController.ready) { return; }
        MoveAccordingToShape();
        if (changeShape) {
            StartCoroutine(ChangeShape());
        }
    }

    private void MoveAccordingToShape() {
        switch (currentShape) {
            case EnemyShape.Square:
                MoveSquare();
                break;
            case EnemyShape.Diamond:
                MoveDiamond();
                break;
            case EnemyShape.Triangle:
                MoveTriangle();
                break;
            case EnemyShape.Rectangle:
                MoveRectangle();
                break;
            default:
                break;
        }
    }

    IEnumerator ChangeShape() {
        changeShape = false;
        yield return new WaitForSeconds(5f);
        switch (currentShape) {
            case EnemyShape.Square:
                currentShape = EnemyShape.Diamond;
                break;
            case EnemyShape.Diamond:
                currentShape = EnemyShape.Triangle;
                break;
            case EnemyShape.Triangle:
                currentShape = EnemyShape.Rectangle;
                break;
            case EnemyShape.Rectangle:
                currentShape = EnemyShape.Ready;
                break;
        }

        changeShape = true;
    }
    #region Move Shape
    private void MoveSquare() {
        for (int i = 0; i < enemy.Length; i++) {
            MoveToTarget(i);
        }
    }
    private void MoveDiamond() {
        targetGridCells[15] = new Vector3Int(4, 1, 0);
        targetGridCells[3] = new Vector3Int(-1, 1, 0);
        targetGridCells[7] = new Vector3Int(2, -1, 0);
        MoveToTarget(15);
        MoveToTarget(3);
        MoveToTarget(7);
    }
    private void MoveTriangle() {
        DrawTriangle();
        for (int i = 0; i < enemy.Length; i++) {
            MoveToTarget(i);
        }
    }
    private void MoveRectangle() {
        DrawRectangle();
        for (int i = 0; i < enemy.Length; i++) {
            MoveToTarget(i);
        }
    }
    private void MoveToTarget(int i) {
        Vector3 targetWorldPosition = tilemap.GetCellCenterWorld(targetGridCells[i]);
        enemy[i].transform.position = Vector3.MoveTowards(enemy[i].transform.position, targetWorldPosition, moveSpeed * Time.deltaTime);
    }
    #endregion

    #region Draw Shape
    private void DrawSquare() {
        targetGridCells = new Vector3Int[enemy.Length];
        for (int i = 0; i < enemy.Length; i++) {
            int row = i / 4;
            int col = i % 4;
            targetGridCells[i] = new Vector3Int(row, col, 0);
        }
    }
    private void DrawTriangle() {
        for (int i = 0; i < 9; i++) {
            targetGridCells[i] = new Vector3Int(i - 1, 0, 0);
        }
        int index = 9; 
        for (int j = 1; j < 4; j++) {
            targetGridCells[index++] = new Vector3Int(j - 1, j, 0);
            targetGridCells[index++] = new Vector3Int(7 - j, j, 0);
        }
        targetGridCells[15] = new Vector3Int(3, 4, 0); 
    }
    private void DrawRectangle() {
        for (int i = 0; i < 7; i++) {
            targetGridCells[i] = new Vector3Int(i, 0, 0);
            targetGridCells[i + 9] = new Vector3Int(i, 2, 0);
        }
        targetGridCells[7] = new Vector3Int(0, 1, 0);
        targetGridCells[8] = new Vector3Int(6, 1 ,0);
    }
    #endregion
}

