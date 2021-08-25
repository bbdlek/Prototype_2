using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class EnemyManager : MonoBehaviour
{
    
    
    public NavMeshSurface surface;
    public UnityEngine.AI.NavMeshPath navMeshPath;
    public UnityEngine.AI.NavMeshAgent agent;
    Transform spawnPos;
    [SerializeField] GameObject _endpoint;
    [SerializeField] GameObject _enemypoint;
    public bool pathAvailable;

    private Wave currentWave;
    GameObject CurrentSpawnenemy;
    public List<GameObject> CurrentEnemyList;

    private int enemySpawnCount = 0;
    [SerializeField]
    private int enemyMaxCount;

    // Start is called before the first frame update
    void Start()
    {
        CurrentEnemyList = new List<GameObject>();
        navMeshPath = new UnityEngine.AI.NavMeshPath();
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;
        StartSpawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BakeNav()
    {
        surface.BuildNavMesh();
    }

    bool CalculateNewPath()
    {
        agent.CalculatePath(_endpoint.transform.position, navMeshPath);
        print("New path calculated");
        if (navMeshPath.status != UnityEngine.AI.NavMeshPathStatus.PathComplete)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void StartSpawn()
    {
        _enemypoint.GetComponent<NavMeshAgent>().enabled = false;
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
        GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex], _enemypoint.transform);
        CurrentSpawnenemy = clone;
        enemySpawnCount++; //k
        CurrentEnemyList.Add(CurrentSpawnenemy); //k
        yield return new WaitForSeconds(2f);
        if (enemySpawnCount < enemyMaxCount) StartCoroutine(EnemySpawner());
    }


}
