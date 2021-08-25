using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Wave
{
    public float spawnTime;
    public int maxEnemyCount;
    public GameObject[] enemyPrefabs;
}

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves;
    [SerializeField]
    private EnemyManager enemySpawner;
    private int currentWaveIndex = -1;
    // Start is called before the first frame update

    public void StartWave()
    {
        if(enemySpawner.CurrentEnemyList.Count ==0 && currentWaveIndex < waves.Length-1)
        {
            currentWaveIndex++;
            enemySpawner.StartWave(waves[currentWaveIndex]);
        }
    }

   
    void Start()
    {
        enemySpawner = this.GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
