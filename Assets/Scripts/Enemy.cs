using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject target;
    NavMeshAgent agent;

    void Start()
    {
        target = GameObject.Find("EndPoint");

        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "EndPoint")
        {
            Destroy(gameObject);
        }
    }

}
