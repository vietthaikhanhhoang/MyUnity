using System.Threading;
using System.Security.Cryptography;
using System;
using System.Runtime.Versioning;
using System.Reflection;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform target; // cua nhan van
    public float smoothing;

    Vector3 offset;

    float lowY;

    // Start is called before the first frame update
    void Start()
    {
        // khoang cach y giua camera va nhan vat
        offset = transform.position - target.position;
        lowY = transform.position.y; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
  
        //khong cho camera roi mai
        if(transform.position.y < lowY) {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
