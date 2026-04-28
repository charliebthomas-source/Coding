

using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using TMPro;
using UnityEngine.EventSystems;





public class Manager : MonoBehaviour
{
    InputAction jumpAction;
    Animator animator;
    Rigidbody2D rb;
    //bool isonthefloor = true;
    Player charlie; //charlie is linking to the player code

    public GameObject platform;

  GameObject player;
 GameObject platform1;

  int numberplatform = 3;

bool hasjumped = false;

int score = 0;

public TextMeshProUGUI scouretyper;

GameObject camera;

bool cmaerapanning = false;

Vector3 camerapstion = new Vector3(0,0,-10);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake() 
    {
        player = GameObject.Find("Player");
        jumpAction = InputSystem.actions.FindAction("Jump");
        platform1 = GameObject.Find("Platform");
        animator = player.GetComponent<Animator>();
       animator.SetBool("OnFloor", true);
       rb = player.GetComponent<Rigidbody2D>();
       charlie = player.GetComponent<Player>();
       GameObject platforms = GameObject.Instantiate(platform,platform1.transform.position + new Vector3(3.1f,0,0),Quaternion.identity);
       platforms.name = "2" ;
        camera = GameObject.Find("Main Camera");
       
       
      //example of how to spawn platform 
       
    }


  


    public void Isonthefloor()
    {
        if(charlie.isonthefloor == true && hasjumped == true ) 
        {
            Debug.Log("true");
            rb.linearVelocityX=0;
           score++;
            hasjumped = false;
            Debug.Log("score"+score);
            cmaerapanning = true;
            
            
        }

        if(charlie.isonthefloor == false && hasjumped == false )
        {
            Debug.Log("false");
            hasjumped = true;
           camerapstion = camerapstion + new Vector3(3.1f,0,0);
        
        }
    }

     
 
  
    // Update is called once per frame 
    void Update()
    {
        Isonthefloor();
        animator.SetBool("OnFloor", charlie.isonthefloor);
        if(jumpAction.IsPressed() && (charlie.isonthefloor == true) && (cmaerapanning == false))
        {
            //animator.SetBool("ButtonPressed", true);
            rb.AddForceX(250);
            rb.AddForceY(500); 
            charlie.isonthefloor = false;

            GameObject previosPlatform = GameObject.Find((numberplatform - 1).ToString());
             GameObject platforms = GameObject.Instantiate(platform,previosPlatform.transform.position + new Vector3(3.1f,0,0),Quaternion.identity);
            platforms.name = numberplatform.ToString();
            numberplatform++; 


    

           

            
        }


        if(cmaerapanning == true)
        {
            //numberplatform the number of the platfor that has just spawned in
            camera.transform.Translate(Vector3.right * Time.deltaTime);
            
        }
        if(camera.transform.position.x > camerapstion.x)
            {
                cmaerapanning = false;
            }
      
        if(numberplatform>10)
        {
          Destroy(platform1);   
        }

        if(numberplatform>11)
        {
             GameObject objecttoremove = GameObject.Find((numberplatform - 10).ToString());
             Destroy(objecttoremove);
        }

        /*else{
            animator.SetBool("ButtonPressed", false);
        }*/
        scouretyper.text = "score: " + score;
    }
}

//preesad a in the air true
//now it hit the triggar on the floor till a is pressed again flse

//hit the floor isonthefloor true 
//hit a button faulse 
// if a button is press set to 

//isonthefloor 


/*
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;       



      
public class ButtonPress : MonoBehaviour
{
    InputAction jumpAction;
    Animator animator;
    Rigidbody2D rigidbody2D;
    
  


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpAction = InputSystem.actions.FindAction("Jump");
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
       
    }
    //if player lands on platform 1 print it landed on platfor 1 ect
    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log(other.gameObject.name);
    }

    public void PLayerJump()
    {
            animator.SetBool("ButtonPressed", true);
            rigidbody2D.AddForceX(5);
            rigidbody2D.AddForceY(5);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(jumpAction.IsPressed())
        {
         PLayerJump();   
        }
        else{
            animator.SetBool("ButtonPressed", false);
        }
        
    }
}

//preesad a in the air true
//now it hit the triggar on the floor till a is pressed again flse

//hit the floor isonthefloor true 
//hit a button faulse 
// if a button is press set to 

//isonthefloor 
*/