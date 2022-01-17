using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    [SerializeField] private AudioClip sun;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GoalBehaviour.musicgoal)
        {
            audioSource.clip = sun;
            audioSource.PlayOneShot(audioSource.clip);
            GoalBehaviour.musicgoal = false;
        }
    }
}
