using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider slider; //ask ai whu this 

    void Start()
    {
        slider.value = 0;
    }

    public void SetProgress(float progress)  //ask ai why this hole thing 
    {
        slider.value = progress; 
    }
}