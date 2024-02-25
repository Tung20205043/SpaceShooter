using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BulletManager : MonoBehaviour
{
    #region Singleton
    public static BulletManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    #endregion
    [SerializeField] Transform holder;
    //[SerializeField] protected GameObject objectToSpawn;
    [SerializeField] protected List<GameObject> poolObj;
    public void SpawnObject(GameObject objectToSpawn, Vector3 spawnPoint, Quaternion spawnRotation) {       
        GetObjectFromBool(objectToSpawn, spawnPoint, spawnRotation);
    }
    protected void GetObjectFromBool(GameObject _poolObj, Vector3 spawnPoin, Quaternion spawnRotation) {
        if (poolObj.Count > 0) {
            foreach (GameObject poolObj in poolObj) {
                if (poolObj.name == _poolObj.name) {
                    this.poolObj.Remove(poolObj);
                    poolObj.transform.position = spawnPoin;
                    poolObj.SetActive(true);
                    poolObj.transform.parent = holder;
                    return;
                }
            }
        }
        GameObject newPoolObj = Instantiate(_poolObj, spawnPoin, spawnRotation);
        newPoolObj.name = _poolObj.name;
        newPoolObj.transform.parent = holder;

    }
    public void DeSpawn(GameObject _poolObj) {
        poolObj.Add(_poolObj);
        _poolObj.SetActive(false);
    }
}
