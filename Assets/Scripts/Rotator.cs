using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    //Rotational Speed
    public float speed = 10f;

    //Forward Direction
    public bool ForwardX = false;
    public bool ForwardY = false;
    public bool ForwardZ = false;

    //Reverse Direction
    public bool ReverseX = false;
    public bool ReverseY = false;
    public bool ReverseZ = false;

    private void Start()
    {
        speed += Random.Range(-30, 31);
        
        int RandomSpin = Random.Range(1, 7);
        switch (RandomSpin)
        {
            case 6:
                ForwardX = true;
                break;
            case 5:
                ForwardY = true;
                break;
            case 4:
                ForwardZ = true;
                break;
            case 3:
                ReverseX = true;
                break;
            case 2:
                ReverseY = true;
                break;
            case 1:
                ReverseZ = true;
                break;
            default:
                ForwardX = true;
                break;
        }
        //Debug.Log(RandomSpin);
    }

    void Update()
    {
        //Forward Direction
        if (ForwardX == true)
        {
            transform.Rotate(Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ForwardY == true)
        {
            transform.Rotate(0, Time.deltaTime * speed, 0, Space.Self);
        }
        if (ForwardZ == true)
        {
            transform.Rotate(0, 0, Time.deltaTime * speed, Space.Self);
        }
        //Reverse Direction
        if (ReverseX == true)
        {
            transform.Rotate(-Time.deltaTime * speed, 0, 0, Space.Self);
        }
        if (ReverseY == true)
        {
            transform.Rotate(0, -Time.deltaTime * speed, 0, Space.Self);
        }
        if (ReverseZ == true)
        {
            transform.Rotate(0, 0, -Time.deltaTime * speed, Space.Self);
        }

    }
}