using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    [SerializeField] private bool doorUp = false;

    public void Start()
    {
        
    }

    public void Update()
    {
        if (ButtonBehaviour.buttonPushed)
        {
            doorChange();
            ButtonBehaviour.buttonPushed = false;
        }
    }

    public void doorChange()
    {
        if (doorUp)
        {
            transform.Translate(0,-10, 0);
            doorUp = false;
        }else
        {
            transform.Translate( 0, 10, 0);
            doorUp = true;
        }
    }
}


