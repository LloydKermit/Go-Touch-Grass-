using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class CooldownBar : MonoBehaviour
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

    public void Cooldown(float CurrentCD)
    {
        slider.maxValue = CurrentCD;
        slider.value = CurrentCD;
    }

    public void setCooldown(float CurrentCD)
    {
        slider.value = CurrentCD;
    }
}
