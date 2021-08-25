using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//k all
public class Bullet : MonoBehaviour
{
   
    public float bulletSpeed;
    private float bulletDamage;
    private Transform target;
    
    
    public void Setup(Transform target, float bulletSpeed, float bulletDamage)
    {
        this.bulletSpeed = bulletSpeed;
        this.target = target;
        this.bulletDamage = bulletDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy")) return;
        if(other.transform != target) return;
        other.GetComponent<Enemy>().GetDamage(bulletDamage);
        Destroy(gameObject);
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            
            transform.LookAt(new Vector3(target.position.x,0.5f,target.position.z));
            this.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, target.position, bulletSpeed * Time.deltaTime);
        } 
        else
        {
            Destroy(gameObject);
        }
    }
}
