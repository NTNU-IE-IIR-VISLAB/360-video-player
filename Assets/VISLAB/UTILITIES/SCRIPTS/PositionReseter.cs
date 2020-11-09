using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReseter : MonoBehaviour
{
    Vector3 startpos;
    void Start()
    {
        this.startpos = this.transform.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            this.transform.position = startpos;
        }
    }
}