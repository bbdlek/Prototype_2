using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float maxHP;
    [SerializeField]
    private Animator anim;
    private float currentHP;
    private bool isDie = false;
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
