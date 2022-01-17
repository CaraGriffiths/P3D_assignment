using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalBehaviour.standgoal)
        {
            transform.Translate(0, -50, 0);
            GoalBehaviour.standgoal = false;
        }
    }
}
