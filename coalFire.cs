using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coalFire : MonoBehaviour
{

    public Rigidbody coal;

    public GameObject playe;

    public Transform playeR;

    public fire fire;
    
     [SerializeField] 
     float reload;

    public float reload2 = 2000f;
    // Start is called before the first frame update
    void Start()
    {
     playe = GameObject.Find("Scout");

    }

    void FixedUpdate()
    {
        reload++;
    }
    // Update is called once per frame
    void Update()
    {
        if(fire.inRange && !fire.ifPutOut)
        {
            transform.LookAt(playeR);
            if(reload > reload2)
            {
                reload = 0;
                Rigidbody clone;
                clone = Instantiate(coal, transform.position, transform.rotation);

           
                clone.velocity = transform.TransformDirection(Vector3.forward * 30);
            }
        }
    }
}
