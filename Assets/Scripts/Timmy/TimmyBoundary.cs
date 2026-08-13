using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimmyBoundary : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 58)
        {
            transform.position = new Vector3(transform.position.x, 58, 0);
        }
    }
}
