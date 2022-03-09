using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
    public float weaponDamage;

    projecttilecontroller myPC;
    public GameObject bulletExplosion; //hieu ung

    void Awake() {
        myPC = GetComponentInParent<projecttilecontroller>(); //xem lai doan nay
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Shootable") {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);

            if(other.gameObject.layer == LayerMask.NameToLayer("enemy")) {
                enemyHeath hurtEnemy = other.gameObject.GetComponent<enemyHeath>();
                hurtEnemy.addDamge(weaponDamage);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if(other.gameObject.tag == "Shootable") {
            myPC.removeForce();
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);

            if(other.gameObject.layer == LayerMask.NameToLayer("enemy")) {
                enemyHeath hurtEnemy = other.gameObject.GetComponent<enemyHeath>();
                hurtEnemy.addDamge(weaponDamage);
            }
        }
    }
}
