using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    private Slider slider;

    public float fillspeed = 0.5f;
    private float targetProgress = 0;
    // Start is called before the first frame update
    void Awake()
    {
        slider = gameObject.GetComponent<Slider>() ;
    }

    private void Start()
    {
        IncrementProgress(1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value > targetProgress)
        {
            slider.value -= fillspeed * Time.deltaTime;
        }   
    }

    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value - newProgress;
    }
}
