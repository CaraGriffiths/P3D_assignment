using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{
    [SerializeField] private bool buttonActive;
    public static bool buttonPushed;
    public static bool lightsOn;
    public static bool orbIn;
    public static bool dollIn;
    public static bool text;

    public void start()
    {
        buttonActive = false;
        buttonPushed = false;
        lightsOn = false;
        orbIn = false;
        dollIn = false;
        text = false;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonActive = true;
            text = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            buttonActive = false;
            text = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonActive && Input.GetKeyDown(KeyCode.E))
        {
            buttonPushed = true;
            if (gameObject.tag == "Light")
            {
                lightsOn = true;
                dollIn = true;
                orbIn = true;
            }
        }
    }
}
