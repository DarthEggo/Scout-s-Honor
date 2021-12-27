using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class levelCounter : MonoBehaviour
{

    public Text levelText;
    public static int levelCount = 0;

    public Transform player;

    public int zBarrier;
    
    // Start is called before the first frame update
    void Start()
    {
       levelCount = 0;
       DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        levelText.text = "Level " + levelCount;
        if (player.transform.position.z > zBarrier)
        {
         levelCount++;
         zBarrier += 210;
        } 
       
    }

    
    

    
}
