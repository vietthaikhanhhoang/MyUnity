using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detroyMe : MonoBehaviour
{
    public float aliveTime;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject != null) {
            Destroy(gameObject, aliveTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
