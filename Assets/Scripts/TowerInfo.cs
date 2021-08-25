using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//k all
public enum WeaponState { SearchTarget, AttackToTarget}

public class TowerInfo : MonoBehaviour
{
    public Vector3[] _myposition;
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private Transform BulletSpawnPoint;
    [SerializeField]
    private float attackRate = 0.5f;
    [SerializeField]
    private float attackRange = 3.5f;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float bulletDamage = 1;

    private WeaponState weaponState = WeaponState.SearchTarget;
    public Transform attackTarget = null;
    public GameObject TowerHead;
    public GameObject SpawnPoint;
    private List<GameObject> enemyList;
    public void Setup()
    {
        SpawnPoint = GameObject.Find("SpawnPoint");
        this.enemyList = SpawnPoint.GetComponent<EnemyManager>().CurrentEnemyList;
        ChangeState(WeaponState.SearchTarget);
    }

    public void ChangeState(WeaponState newState)
    {
        StopCoroutine(weaponState.ToString());
        weaponState = newState;
        StartCoroutine(weaponState.ToString());
    }

    private void RotateToTarget()
    {
        Debug.Log("rotating");
        TowerHead.transform.LookAt(new Vector3(attackTarget.position.x, TowerHead.transform.position.y, attackTarget.position.z));
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            float closestDistSqr = Mathf.Infinity;
            for (int i = 0; i < enemyList.Count; ++i)
            {
                if (enemyList[i] == null)
                    continue;

                float distance = Vector3.Distance(enemyList[i].transform.position, transform.position);
                if (distance <= attackRange && distance <= closestDistSqr)
                {
                    closestDistSqr = distance;
                    attackTarget = enemyList[i].transform;
                }
            }
            if (attackTarget != null)
            {
                ChangeState(WeaponState.AttackToTarget);
            }
            yield return null;
        }
    }

    private IEnumerator AttackToTarget()
    {
        while (true)
        {
            if (attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            float distance = Vector3.Distance(attackTarget.position, transform.position);
            if (distance > attackRange)
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }
            yield return new WaitForSeconds(attackRate);


            SpawnBullet();
        }
    }
    private void SpawnBullet() 
    {
        GameObject clone = Instantiate(BulletPrefab, BulletSpawnPoint.position, Quaternion.identity);
        clone.GetComponent<Bullet>().Setup(attackTarget, bulletSpeed, bulletDamage);
        
        }

        void Start()
        {
            Setup();
        }

        // Update is called once per frame
        void Update()
        {

            if (attackTarget != null)
            {
                RotateToTarget();
            }
        }
    
}
