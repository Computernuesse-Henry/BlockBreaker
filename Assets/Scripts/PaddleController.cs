using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        var mouseposx = (Input.mousePosition.x / Screen.width * 16f);
        Vector2 mouseVector = new Vector2(mouseposx, 0.254f);
        transform.position = mouseVector;

        
    }
}
