using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class HealthBar : MonoBehaviour
{
    public Transform Timmy;
    public Slider slider;

    Vector3 Offset;

    void Start()
    {
        if (Timmy != null)
        {
            Offset = transform.position - Timmy.position;
        }
    }

    void LateUpdate()
    {
        if (Timmy != null)
        {
            transform.position = Timmy.position + Offset;
        }
    }

    public void maxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }
}
