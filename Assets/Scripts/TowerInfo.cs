using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour
{
    public Vector3[] _myposition;
    [SerializeField]
    private float numberOfBlocks;
    public TowerHead[] TowerHeads;
    public bool isTemp = true;
    public GameObject BulletPrefab;
    public float bulletSpeed;
    public float bulletDamage = 1;
    public float attackRate = 0.5f;
    public float attackRange = 3.5f;
    // Start is called before the first frame update
    public void ConfirmTowerPosition()
    {
        isTemp = false;
        gameObject.layer = LayerMask.NameToLayer("Floor");
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.layer = LayerMask.NameToLayer("Floor");
        }
    }
    public void Setup() //공격성타워 속성 세팅
    {for (int i = 0; i < TowerHeads.Length; i++)
        {
            TowerHeads[i].BulletPrefab= this.BulletPrefab ;
            TowerHeads[i].bulletSpeed = this.bulletSpeed;
            TowerHeads[i].bulletDamage = this.bulletDamage;
            TowerHeads[i].attackRate = this.attackRate;
            TowerHeads[i].attackRange = this.attackRange;
            
            
        }
    }

    void Start()
    {
        if (TowerHeads.Length > 0) //공격성 타워 존재할때 setup 실행
            Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
