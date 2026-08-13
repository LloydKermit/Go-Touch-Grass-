using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreSoulCount : MonoBehaviour
{
    public TextMeshProUGUI soulsText;

    public void Awake()
    {
        soulsText.text = "Souls Needed: " + WinLose.soulsNeeded.ToString();
    }
    public void decreaseSoul()
    {
        if (WinLose.soulsNeeded > 0)
        {
            WinLose.soulsNeeded--;
            soulsText.text = "Souls Needed: " + WinLose.soulsNeeded.ToString();
        }

    }
}
