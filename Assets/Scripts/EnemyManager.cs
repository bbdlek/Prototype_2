using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    public NavMeshSurface surface;
    public UnityEngine.AI.NavMeshPath navMeshPath;
    public UnityEngine.AI.NavMeshAgent agent;
    Transform spawnPos;
    [SerializeField] GameObject _endpoint;

    [SerializeField] GameObject _enemypoint;
    public bool pathAvailable;

    // Start is called before the first frame update
    void Start()
    {
        navMeshPath = new UnityEngine.AI.NavMeshPath();
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
        Instantiate(Enemy, _enemypoint.transform);
        yield return new WaitForSeconds(1f);
        StartCoroutine(EnemySpawner());
    }


}
