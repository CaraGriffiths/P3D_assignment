using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBehaviour : MonoBehaviour
{
    [SerializeField] private bool beginning;
    // Start is called before the first frame update
    public void Start()
    {
        transform.Translate(0, -50, 0);
        beginning = true;
    }

    // Update is called once per frame
    public void Update()
    {
        if (ButtonBehaviour.lightsOn)
        {
            if (beginning)
            {
                LightChangePositive();
            }
            ButtonBehaviour.lightsOn = false;
        }
        if (OrbBehaviour.lighting)
        {
            LightChangeNegative();
        }

    }

    public void LightChangePositive()
    {
        transform.Translate(0, 50, 0);
        beginning = false;
    }

    public void LightChangeNegative()
    {
        transform.Translate(0, -50, 0);
        beginning = false;
    }
}
