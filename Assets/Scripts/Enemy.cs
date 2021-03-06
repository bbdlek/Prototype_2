using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private Animator anim;
    
    private float currentHP;
    private bool isDie = false;
    private bool isWalking = true;
    public float hitDamage;
    GameObject target;
    GameObject Player;
    NavMeshAgent agent;

    

    public GameObject GameManagerObject;


    

    void Start()
    {
        currentHP = maxHP;
        anim = this.GetComponent<Animator>();
        GameManagerObject = GameObject.Find("SpawnPoint"); //k
        target = GameObject.Find("EndPoint");
        Player = GameObject.Find("Player1");
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(target.transform.position);

        
    }
    private void Update()
    {
        AgentStuckAvoid();

    }

    public void AgentStuckAvoid()
    {
        if (isWalking && !agent.hasPath && agent.pathStatus == NavMeshPathStatus.PathComplete && agent.speed > 0.3)
        {
            Debug.LogWarning("enemy Repathing!!");
            agent.enabled = false;
            agent.enabled = true;
            agent.SetDestination(target.transform.position);
            agent.speed = moveSpeed;
        }
    }
    
    public void GetDamage(float Damage) //k
    {
        currentHP -= Damage;
        if (currentHP <= 0)
        {
            isDie = true;
            GameManagerObject.GetComponent<EnemyManager>().CurrentEnemyList.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isWalking = false;
            StartCoroutine(HitPlayer());
            
           
        }
        
    }

    IEnumerator HitPlayer()
    {

        anim.SetBool("ContactPlayer", true);
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(Player.GetComponent<Player>().GetHitCoroutine(hitDamage));
        GameManagerObject.GetComponent<EnemyManager>().CurrentEnemyList.Remove(gameObject);
        yield return new WaitForSeconds(0.7f);
        Destroy(gameObject);
    }



    


}
