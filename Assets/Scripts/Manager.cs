

using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;




//we need to make the scor correlte to the platform the player is on e
// make it so when the player gose out of screen. below we reset the game and the conter 




public class Manager : MonoBehaviour
{
    InputAction jumpAction;
    
    Animator animator;
    
    Rigidbody2D rb;
    
    Player charlie; 

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

public Slider slider;


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
        slider = FindFirstObjectByType<Slider>();
    }


   
       



    public void Isonthefloor()
    {
        if(charlie.isonthefloor == true && hasjumped == true ) 
        {
            Debug.Log("true");
            rb.linearVelocityX=0;
            hasjumped = false;
            Debug.Log("score"+score);
           jumpedonce = true;
           score++;
        }
        
        if(charlie.isonthefloor == false && hasjumped == false )
        {
            Debug.Log("false");
            hasjumped = true;
        }
    }
    
    

    public void Jumpingforce()
    {
        if(jumpAction.IsPressed() && (timer < 10) && (cmaerapanning == false))
        {
            timer += Time.deltaTime;
        }
        if(jumpAction.WasReleasedThisFrame() && (charlie.isonthefloor == true) && (cmaerapanning == false))
        {
            
            float jumpForce = 200 + (timer * 50);
            rb.AddForceX(jumpForce);
            rb.AddForceY(500);
            charlie.isonthefloor = false;
            timer = 0;

            previosPlatform = GameObject.Find((numberplatform - 1).ToString());
            GameObject platforms = GameObject.Instantiate(platform,previosPlatform.transform.position + new Vector3(Random.Range(2.0f, 4.0f), 0, 0), Quaternion.identity);
            platforms.name = numberplatform.ToString();
            numberplatform++; 
            
            cmaerapanning = true;
        }
    }
    
    
    



    public void Slidercontrolls()
    {
            if (Mathf.Abs(camera.transform.position.x - center.x) < 0.05f)
            {
                if ((charlie.isonthefloor == true) || (timer == 0))
                {
                    slider.value = timer / 10f;
                }
            }
            

    }

    
    

    public void scoreconting()
    {
        scouretyper.text = "score: " + score;
    }
    
    

    public void camerapan()
    {
        
        
        if (previosPlatform != null) 
        {
            Vector3 locationofpreviosplatform = previosPlatform.transform.position;
            GameObject nextPlatform = GameObject.Find((numberplatform - 1).ToString()); 

            if (nextPlatform != null)
            {
                center = (locationofpreviosplatform + nextPlatform.transform.position) / 2f;

                if (jumpedonce == true && charlie.isonthefloor == true )
                {
                    camera.transform.position = new Vector3(
                        Mathf.Lerp(camera.transform.position.x, center.x, 0.01f),
                        camera.transform.position.y,
                        camera.transform.position.z
                    );
                    
                }
                
            }
        }
        if (Mathf.Abs(camera.transform.position.x - center.x) < 0.05f)
        {
            cmaerapanning = false;
        }
    }

    
    
    
    public void destroyplatforms()
    {
        if(numberplatform>10)
        {
            Destroy(platform1);   
        }
        if(numberplatform>11)
        {
            GameObject objecttoremove = GameObject.Find((numberplatform - 10).ToString());
            Destroy(objecttoremove);
        }
    }
    
    
    
    
    void Update()
    {
        
        Jumpingforce();
        Slidercontrolls();
        scoreconting();
        Isonthefloor();
        destroyplatforms();
        camerapan();
        animator.SetBool("OnFloor", charlie.isonthefloor);
        
    }
}

