using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomGen : MonoBehaviour
{


    //Variables
    public AudioSource audio1;
    private float z = 15;
    public float y;
    private float randomA;

    public Transform ground1;

    public Transform ground2;

    public Transform ground3;

    public Transform ice1;

    public Transform ice2;

    public Transform ice3;

    public Transform mount1;

    public Transform mount2;

    public Transform mount3;

    public Transform snow1;

    public Transform snow2;

    public Transform snow3;

    public Transform finish;

    public Transform camera;
   
    public Transform BoyScoutPlayer;

    public float finishZ;

    public float finishTimes;

    public int levelNum;

    

    private int LevelBarrier = 210;

    




    
    void Awake()
    {
       
        GenerateMap(); 
        
    }
    void Start()
    {
      
         
    }

    
    void Update()
    {
        if(BoyScoutPlayer.transform.position.z > LevelBarrier)
        {
            audio1.Play();
            LevelBarrier += 210;
            GenerateMap();
        }
    }

    void GenerateMap()
    {
        levelNum = Random.Range(1,4);
        if(levelNum == 1)
        {
        for (int i = 0; i < 10; i++)
        {
            z += 25;
            randomA = Random.Range(0,3);
            if(randomA == 0)
            Instantiate(ground1, new Vector3(0, 1, z), Quaternion.identity);
            if (randomA == 1)
            {
                Instantiate(ground2, new Vector3(0, -3, z), Quaternion.identity);
            }
            if (randomA == 2)
            {
                Instantiate(ground3, new Vector3(0, -1, z), Quaternion.identity);
            }
            
            finishZ = 15;
        }    
        }
        else if(levelNum == 2)
        {
           for (int i = 0; i < 10; i++)
        {
            z += 25;
            randomA = Random.Range(0,3);
            if(randomA == 0)
            Instantiate(ice1, new Vector3(0, 0, z), Quaternion.identity);
            if (randomA == 1)
            {
                Instantiate(ice2, new Vector3(0, 0, z), Quaternion.identity);
            }
            if (randomA == 2)
            {
                Instantiate(ice3, new Vector3(0, 0, z), Quaternion.identity);
            }
            else
            {
            Debug.Log("null");
            }
            
            finishZ = 15;
        }    
         
        }
        else if(levelNum == 3)
        {
          for (int i = 0; i < 10; i++)
        {
            z += 25;
            randomA = Random.Range(0,3);
            y = Random.Range(0,11);
            if(y < 5 )
            {

            
            if(randomA == 0)
            Instantiate(snow1, new Vector3(0, y, z), Quaternion.identity);
            if (randomA == 1)
            {
                Instantiate(snow2, new Vector3(0, y, z), Quaternion.identity);
            }
            if (randomA == 2)
            {
                Instantiate(snow3, new Vector3(0, y, z), Quaternion.identity);
            }
            else
            {
            Debug.Log("null");
            }
            
            finishZ = 15;
        }
        else
        {
          if(randomA == 0)
            Instantiate(mount1, new Vector3(0, y, z), Quaternion.identity);
            if (randomA == 1)
            {
                Instantiate(mount2, new Vector3(0, y, z), Quaternion.identity);
            }
            if (randomA == 2)
            {
                Instantiate(mount3, new Vector3(0, y, z), Quaternion.identity);
            }
            else
            {
            Debug.Log("null");
            }  
        }    
        }
        }
        else
        {
            Debug.Log("null");
        }
    }
}
