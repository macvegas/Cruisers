using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text count;

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        UpdateCount();
    }

    public void SetCurrentHealth(float health)
    {
        slider.value = health;
        UpdateCount();
    }

    public void UpdateCount()
    {
        count.text = slider.value + " / " + slider.maxValue;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
