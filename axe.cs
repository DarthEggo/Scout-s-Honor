using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axe : MonoBehaviour
{
    public float spin;
    public GameObject weapon; 

    public bool ifClone;
    // Start is called before the first frame update
    void Start()
    {
        if(ifClone)
        {
            Destroy(gameObject, 5);
        }
    }

     void OnCollisionEnter(Collision collision)
    {
      if (collision.gameObject.tag == "enemy")
      {
        
        Destroy(gameObject);
      }
    }
    void FixedUpdate()
    {
        weapon.transform.Rotate(spin,0,0);
    }

  
}
