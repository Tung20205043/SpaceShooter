using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScroll : MonoBehaviour
{
    private readonly float scrollSpeed = 0.4f;
    private Material mat;
    private Vector2 offset = Vector2.zero;
    private void Awake() {
        mat = GetComponent<Renderer>().material; 
    }
    private void Start() {
        offset = mat.GetTextureOffset("_MainTex");
    }
    private void Update() {
        if (GamePlayManager.gameState != GameState.Play) { return; }


        offset.y += scrollSpeed * Time.deltaTime;
        mat.SetTextureOffset("_MainTex", offset);
    }
}
