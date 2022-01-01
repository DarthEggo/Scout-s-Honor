using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public Text healthText;
    public Rigidbody axe;

    public float reload;
    public float reloadWait;
    public AudioSource audio;
    private GameObject camera;
    public CharacterController pcontrol;

    public AudioSource axeHit;
    
  
    
    float x;
    public float playerZ;
    Vector3 move;

    float playerSpeed;

    
    float jumpReload = 1000;

    public float recharge;
    public float speed = 12;
    public float gravity = -2;


    Vector3 tetherPoint;

    float tetherLength;
    Vector3 velocity;

    public Transform end;

    public float endZ;

    public float ifEnd;

    public bool ifFinished = false;

    public ability ability;

    public GameObject abilityObj;

    public int health = 5;

    

    

//Check if player is on ground
    public Transform groundCheck;

    public Transform mountCheck;

    public float groundDistance;

    public bool isGrounded;

    public bool isIce;

    public bool isClimb;

    public bool isIceClimb;

    Rigidbody rb;

    public LayerMask groundMask;

    public LayerMask iceMask;

    public float jumpHeight = 3f;

    public Vector3 cameraOffset;

    public ParticleSystem water;

    public bool ifDouble;

    public bool ifJump;

    public float ice;

    public float xOffset;

    public bool putOut;

    void Start()
    {
      rb = GetComponent<Rigidbody>();

      abilityObj = GameObject.Find("ability");

      ability = abilityObj.GetComponent(typeof(ability)) as ability;
    }

    void OnCollisionEnter (Collision collision)
    {
      if (collision.gameObject.tag == "coal")
      {
        Debug.Log("hit");
        health -= 1;
        
        
      }
    }
    void LateUpdate()
    {
      healthText.text = "Health: " + health;
      camera = GameObject.Find("MainCamera");
       camera.transform.position = transform.position + cameraOffset;
       jumpHeight = 3f;
       
       
    }
    void FixedUpdate()
    {
      
      reload++;
      if(Input.GetMouseButton(0))
      {
      if (reload > reloadWait)
            {
            
              water.Play();
              putOut = true;
            
            }
        
      }
     

      else{
          putOut = false;
        }
      
        //super jump
        cameraOffset = new Vector3(xOffset, 5, 0);
        recharge++;
        if(Input.GetKey(KeyCode.Return))
        {
          if (ability.abilityID == 2)
          {
          gravity = -2;
          speed = 25;
          }
        }

        else
        {
          gravity = -10;
          speed = 20;
        }
       isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
       isIce = Physics.CheckSphere(groundCheck.position, groundDistance, iceMask);
       isIceClimb = Physics.CheckSphere(mountCheck.position, groundDistance, iceMask);
       isClimb = Physics.CheckSphere(mountCheck.position, groundDistance, groundMask);

      
      if(ability.abilityID == 4 && recharge > 500)
        {
      if(Input.GetKeyDown(KeyCode.Return))
          {
          recharge = 0;
          speed = 100;
          }
        }

     if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
      {
        
        transform.rotation = Quaternion.Euler(0, 0, 0);
        playerSpeed = speed;
       
        
      }

       if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    {
      
        transform.rotation = Quaternion.Euler(0, 180, 0);
        playerSpeed = -speed;
       
      } 
        

      playerZ = Input.GetAxis("Horizontal");

      
       if(isIce)
       {
         ice = 1.5f;
       }
       else
       {
         ice = 1;
       }
       move = transform.forward * playerZ * ice;

       pcontrol.Move(move * playerSpeed * Time.deltaTime);

       velocity.y += gravity * Time.deltaTime;

       pcontrol.Move(velocity * Time.deltaTime);

       

        if (transform.position.y < -10 || health < 1)
        {

            SceneManager.LoadScene("Scene");
            
        }
        if (Input.GetKey(KeyCode.Escape))
        {
          SceneManager.LoadScene("Menu");
        }

        


    }

    

   
    
    void Update()
    {
      
        if (isGrounded || isIce)
        {
          ifJump = true;
        }
        else
        {
          ifJump = false;
        }
        if (transform.position.y > 20)
        {
          xOffset = 30;
        }
        else if (transform.position.y < 20 && ifJump)
        {
          xOffset = 14;
        }
         if(Input.GetButtonDown("Jump") && ifJump)
       {

          
         if (Input.GetKey(KeyCode.Z) && recharge > jumpReload && ability.abilityID == 3)
         {
           recharge = 0;
           jumpHeight = 30;
         }
         if (!ifDouble)
         {
           ifDouble = true;

         }
         
        
         
         audio.Play();
          velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

       
          
       }

        else if(Input.GetButtonDown("Jump") && ability.abilityID == 1)
       {
           
              if(ifDouble)
              {
          
          
                  
                
                ifDouble = false;
                
                audio.Play();
                  velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                  Debug.Log("Jump");
              }
         
         
         
         }
         else if(isClimb)
         {
           
           
           velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
           Debug.Log("test");
           
         }
         else if(isIceClimb)
         {
            
           
           velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
           Debug.Log("test");
           
         }

       
          
       }

       
}

       
    


