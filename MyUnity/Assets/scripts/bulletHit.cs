using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{
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

        }
    }
}
