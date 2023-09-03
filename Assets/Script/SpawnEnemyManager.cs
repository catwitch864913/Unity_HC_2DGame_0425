using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    [Header("生成怪物系統陣列")]
    public SpawnSystem[] spawnSystems;
    [Header("生成怪物資料")]
    public DataSpawnEnemy[] dataSpawnEnemies;

    public float timer;
    public int index;

    void Update()
    {
        ChangeSpawnEnemy();
    }
    private void ChangeSpawnEnemy()
    {
        timer += Time.deltaTime;

        if (index >= dataSpawnEnemies.Length) return;

        if (timer >= dataSpawnEnemies[index].timeToSpawn)
        {
            if (index == dataSpawnEnemies.Length - 1)
            {
                int random = Random.Range(0, spawnSystems.Length);
                Vector3 pos = spawnSystems[random].transform.position;
                Instantiate(dataSpawnEnemies[index].prefabEnemy, pos, Quaternion.identity);
                index++;
                return;
            }
            for (int i = 0; i < spawnSystems.Length; i++)
            {
                spawnSystems[i].prefabEnemy = dataSpawnEnemies[index].prefabEnemy;
                spawnSystems[i].inverval = dataSpawnEnemies[index].intervalSpawn;
                spawnSystems[i].Restart();
            }
            index++;
        }
    }
}
