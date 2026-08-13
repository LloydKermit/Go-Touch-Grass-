using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public Sprite DeadGrass;
    public Sprite AliveGrass;
    public WinLose winLose;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (WinLose.soulsNeeded <= 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = AliveGrass;

        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().sprite == AliveGrass)
        {
            if (collision.tag == "Player")
            {
                winLose.Win();
            }
        }
    }
}
