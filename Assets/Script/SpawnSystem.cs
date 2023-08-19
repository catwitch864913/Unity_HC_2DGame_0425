using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    [Header("�ͦ�����ɶ�"), Range(0, 10)]
    public float inverval = 3.5f;
    [Header("�Ǫ��w�m��")]
    public GameObject prefabEnemy;

    private void Awake()
    {
        //���Ʀ��{���X(�n���ƩI�s��,�X���}�l,���j�X��)
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
