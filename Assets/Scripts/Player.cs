using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
  Rigidbody2D playerPhysics;

   public bool isonthefloor = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPhysics = gameObject.GetComponent<Rigidbody2D>();
    }

  
      //if player lands on platform 1 print it landed on platfor 1 ect
      private void OnTriggerEnter2D(Collider2D other)
      {
          if (other.gameObject.CompareTag("Platform"))// make the polatform tag platfor and make this and if true statment 
          {
              Debug.Log(other.gameObject.name);
              isonthefloor = true;
          }
         if (other.gameObject.name == "Die")
        {
            SceneManager.LoadScene("Main Game");//we will have here insted a game over screen where they can manuly restart the game 
          }
          
          
          

      }

   
      
      
}
