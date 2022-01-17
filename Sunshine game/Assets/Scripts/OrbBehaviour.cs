using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbBehaviour : MonoBehaviour
{
    [SerializeField] private bool beginning;
    [SerializeField] private bool orbActive;
    [SerializeField] private bool orbInPlay;
    [SerializeField] private bool initial;
    [SerializeField] private float throwForce;
    public static bool movement;
    public static bool lighting;
    public GameObject PlayerCam;
    public GameObject PlayerCapsule;
    public static bool music;
    public static bool text;
    // Start is called before the first frame update
    public void Start()
    {
        this.GetComponent<Rigidbody>().useGravity = false;
        transform.Translate(0, -50, 0);
        beginning = true;
        PlayerCam = GameObject.FindWithTag("CinemachineTarget");
        PlayerCapsule = GameObject.FindWithTag("Player");
        orbInPlay = false;
        movement = false;
        initial = true;
        lighting = false;
        throwForce = 400;
        text = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            orbActive = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            orbActive = false;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (ButtonBehaviour.orbIn)
        {
            if (beginning)
            {
                OrbChange();
            }
            ButtonBehaviour.orbIn = false;
        }
        if (orbActive && Input.GetKeyDown(KeyCode.E))
        {
            this.transform.SetParent(PlayerCam.transform);
            transform.localPosition = new Vector3(0, 0, 1);
            this.GetComponent<Rigidbody>().velocity = Vector3.zero;
            this.GetComponent<Rigidbody>().useGravity = false;
            text = false;
            if (initial)
            {
                movement = true;
                lighting = true;
                initial = false;
                music = true;
            }
        }
        if (orbInPlay)
        {
            transform.localPosition = new Vector3(0, 0, 1);
        }
        if(orbActive && Input.GetKeyDown(KeyCode.F))
        {
            this.transform.SetParent(null);
            this.GetComponent<Rigidbody>().useGravity = true;
            this.GetComponent<Rigidbody>().AddForce(PlayerCapsule.transform.forward * throwForce);
            this.GetComponent<Rigidbody>().velocity *= 0.5f;
        }
    }

    public void OrbChange()
    {
        transform.Translate(0, 50, 0);
        this.GetComponent<Rigidbody>().useGravity = true;
        beginning = false;
    }

    

}
