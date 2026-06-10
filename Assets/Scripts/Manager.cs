

using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;



//i can jump when camera is moving gravity is also set to 0 making player fly
//make camera panning work 
//jump varible distance work 
//make it so that the player is not able to relse the buttong and then click again and add more power
// for the variable jump i would use a ui scrollbar and make it own skript ect. 




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
 
float timer = 0;

public TextMeshProUGUI scouretyper;

GameObject camera;

bool cmaerapanning = false;

Vector3 camerapstion = new Vector3(0,0,-10);
GameObject previosPlatform;
bool jumpedonce = false;
private Vector3 center = new Vector3(0, 0, 0); 

public Slider slider;//ask ai this



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
        slider = FindFirstObjectByType<Slider>();//ask ai this
       
       
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
           // cmaerapanning = true;
           jumpedonce = true;
            
            
            
        }

        

        if(charlie.isonthefloor == false && hasjumped == false )
        {
            Debug.Log("false");
            hasjumped = true;
          // camerapstion = camerapstion + new Vector3(3.1f,0,0);
        
        }
    }

     
 //hello
  
    // Update is called once per frame 
    void Update()
    {
        
        

        if (center.x < camera.transform.position.x + 0.0001f )
        {
            Debug.Log("this is now working");
            cmaerapanning = false;
        }
        
        if(jumpAction.IsPressed() && (timer < 10))
        {
        timer += Time.deltaTime;
       
        }

        slider.value = timer / 10f;
        if (slider == null) //ask ai if i need this 
        {
            Debug.LogError("Manager slider is NULL");
        }
              
        Debug.Log(slider);
        
       
        Debug.Log(timer);
        
        Isonthefloor();
        animator.SetBool("OnFloor", charlie.isonthefloor);
        if(jumpAction.WasReleasedThisFrame() && (charlie.isonthefloor == true) && (cmaerapanning == false))
        {
            
            float jumpForce = 100 + (timer * 200);
            rb.AddForceX(jumpForce);
            rb.AddForceY(500);
            charlie.isonthefloor = false;
            timer = 0;

              previosPlatform = GameObject.Find((numberplatform - 1).ToString());
             GameObject platforms = GameObject.Instantiate(platform,previosPlatform.transform.position + new Vector3(Random.Range(2.0f, 4.0f), 0, 0), Quaternion.identity);
            platforms.name = numberplatform.ToString();
            numberplatform++; 
            


            

           

            /**/

        }
       if (previosPlatform != null) /*i used ai to help solve the issue of it not working this line i dont know why*/
        {
            Vector3 locationofpreviosplatform = previosPlatform.transform.position;
            GameObject nextPlatform = GameObject.Find((numberplatform - 1).ToString());/*i used ai to help solve the issue of it not working this line i dont know why*/

            if (nextPlatform != null)/*i used ai to help solve the issue of it not working this line i dont know why*/
            {
               center = (locationofpreviosplatform + nextPlatform.transform.position) / 2f;

                if (jumpedonce == true && charlie.isonthefloor == true)
                {
                    cmaerapanning = true;
                    camera.transform.position = new Vector3(
                        Mathf.Lerp(camera.transform.position.x, center.x, 0.01f),
                        camera.transform.position.y,
                        camera.transform.position.z
                    );
                    
                }
                
            }
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

