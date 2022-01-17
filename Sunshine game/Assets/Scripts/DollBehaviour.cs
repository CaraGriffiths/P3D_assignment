using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollBehaviour : MonoBehaviour
{
    [SerializeField] private bool beginning;
    [SerializeField] private bool clash;
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    private float speed = 2.0f;
    public Transform target;
    private Animator anim;
    private bool animgo;

    // Exposed audio variables
    [Header("Audio")]
    [SerializeField] private AudioClip sun;
    private AudioSource audioSource;

    // Start is called before the first frame update
    public void Start()
    {
        transform.Translate(0, -50, 0);
        beginning = true;
        this.GetComponent<Rigidbody>().useGravity = false;
        wayPoint = GameObject.FindWithTag("waypoint");
        target = GameObject.FindWithTag("Player").transform;
        animgo = true;
        anim = this.GetComponent<Animator>();
        clash = false;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (ButtonBehaviour.dollIn)
        {
            if (beginning)
            {
                DollChange();
                audioSource.clip = sun;
                audioSource.PlayOneShot(audioSource.clip);
            }
            ButtonBehaviour.dollIn = false;
        }
        if (GoalBehaviour.goal)
        {
            wayPointPos = new Vector3(wayPoint.transform.position.x, wayPoint.transform.position.y, wayPoint.transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
            transform.Rotate(0, 0, 0);
            transform.LookAt(target);
            anim.Play("walk");
            animgo = false;
        }
        if (OrbBehaviour.music)
        {
            audioSource.Stop();
            OrbBehaviour.music = true;
        }
    }

    public void DollChange()
    {
        transform.Translate(0, 50, 0);
        this.GetComponent<Rigidbody>().useGravity = true;
        beginning = false;
    }

}
