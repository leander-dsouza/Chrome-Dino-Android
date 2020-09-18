using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public Material material;
    public float xVel = 0.1f;
    Vector2 offset;


    // Speed variables :
    public float accelerationTime = 60;
    private float minSpeed = 0.5f;
    private float time;
    float maxSpeed = 1.695f;


    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {                
        offset = new Vector2(xVel, 0); //move along x-axis, y is 0
        material.mainTextureOffset += offset * Time.deltaTime;//frame time


        xVel = Mathf.SmoothStep(minSpeed, maxSpeed, time / accelerationTime);
        time += Time.deltaTime;



    }
}
