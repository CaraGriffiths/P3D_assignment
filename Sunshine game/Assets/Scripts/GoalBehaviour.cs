using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    [SerializeField] private bool goalActive;
    public static bool goal;
    public static bool standgoal;
    public static bool musicgoal;
    // Start is called before the first frame update
    void Start()
    {
        goalActive = false;
        goal = false;
        standgoal = false;
        musicgoal = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            goalActive = true;
            goal = true;
            standgoal = true;
            musicgoal = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            goalActive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
