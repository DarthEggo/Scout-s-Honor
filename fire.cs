using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    
    public GameObject player;

    public player play;

    public ParticleSystem blaze;

    public float distance = 20;

    public Vector3 playerDis;

    public bool inRange;

    public bool ifPutOut;

    float sqrDis;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.Find("Scout");
        play = player.GetComponent<player>();
        blaze = GetComponentInChildren<ParticleSystem>();
        blaze.Play();
       
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine("checkFire");
        playerDis = player.transform.position - transform.position;
        sqrDis = playerDis.sqrMagnitude;


        if(sqrDis < distance)
        {
            inRange = true;
        } 
        else
        {
            inRange = false;
        }
    }
    public IEnumerator checkFire()
    {
        if(inRange && play.putOut)
        {
            ifPutOut = true;
        }
        if(!ifPutOut)
        {
            blaze.Play();
        }
        yield return new WaitForSeconds(1);
    }
}
