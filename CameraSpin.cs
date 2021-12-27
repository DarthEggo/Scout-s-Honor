using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSpin : MonoBehaviour
{

    public GameObject cam;
    public float spinAmount;
  
    void Start()
    {
        
    }

    void FixedUpdate()
    {
         cam.transform.Rotate(0,spinAmount,0);
    }
}
