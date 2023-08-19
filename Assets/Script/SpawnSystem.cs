using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [Header("生成間格時間"), Range(0, 10)]
    public float inverval = 3.5f;
    [Header("怪物預置物")]
    public GameObject prefabEnemy;

    private void Awake()
    {
        //重複此程式碼(要重複呼叫的,幾秒後開始,間隔幾秒)
        InvokeRepeating("SpawnEnemy", 1.5f, inverval);
    }

    private void SpawnEnemy()
    {
        Instantiate(prefabEnemy, transform.position, Quaternion.identity);
    }
    public void Restart()
    {
        CancelInvoke();
        InvokeRepeating("SpawnEnemy", 0, inverval);
    }
}
