using UnityEngine;

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
    private void OnTriggerStay2D(Collider2D other) 
    {
        Debug.Log(other.gameObject.name);
        isonthefloor = true;

        if(other.gameObject.name == "6")
    {
      playerPhysics.gravityScale = 0;
      playerPhysics.linearVelocity = Vector2.zero;
    }
    }
}
