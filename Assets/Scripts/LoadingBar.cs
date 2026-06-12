using UnityEngine;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{
    public Slider slider;

    void Start()
    {
        slider.value = 0;
    }

    public void SetProgress(float progress)  
    {
        slider.value = progress; 
    }
}