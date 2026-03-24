using UnityEngine;   

public class Dog : MonoBehaviour

{
    int numberOfLegs;
    

    public Dog( int _numberOfLegs )
    {
        numberOfLegs=_numberOfLegs;
    
    }
    
    public void Barks()
    {
        Debug.Log("arf!");
    }
    public int Getnumoflegs()
    {
        return numberOfLegs;
    }
    

}


