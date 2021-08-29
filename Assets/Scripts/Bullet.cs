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
    private void OnTriggerEnter(Collider other) //���� �浹�� ��ȣ�ۿ�
    {
        if (other.gameObject.layer != 12) return;
        if(other.transform != target) return;

        if (other.CompareTag("GroundEnemy"))
            other.GetComponent<GroundEnemy>().GetDamage(bulletDamage);
        else if (other.CompareTag("FlyingEnemy"))
            other.GetComponent<FlyingEnemy>().GetDamage(bulletDamage);
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
            //���ع������� �߻�
            Vector3 aimPosition = new Vector3(target.position.x, 0.5f, target.position.z); //k
            transform.LookAt(aimPosition);
            this.transform.position = Vector3.MoveTowards(this.transform.position, aimPosition, bulletSpeed * Time.deltaTime);
        } 
        else
        {
            Destroy(gameObject); //�� �Ҹ�� ��ü �ı�
        }
    }
}
