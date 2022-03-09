using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projecttilecontroller : MonoBehaviour
{
    public float bulletSpeed;
    Rigidbody2D myBody;
    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        
        // Neu vien dan dang quay nguoc
        if(transform.localRotation.z > 0) {
            myBody.AddForce(new Vector2(-1, 0) * bulletSpeed, ForceMode2D.Impulse);
        } else {
            myBody.AddForce(new Vector2(1, 0) * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Tao chuc nang lam vien dan dung lai
    public void removeForce() {
        myBody.velocity = new Vector2(0, 0);
    }
}
