using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedSpectatorScript : MonoBehaviour
{
    private RedPlayerScript redPlayer;
    public float jumpForce;
    public GameObject redPlayerGameObject;


    private bool grounded;
    private Rigidbody rb;

    

    // Start is called before the first frame update
    void Start()
    {
        redPlayerGameObject = GameObject.Find("Red Player");
        redPlayer = redPlayerGameObject.GetComponent<RedPlayerScript>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Stadium"))
        {
            grounded = true;
        }
    }
    public void Jump()
    {
        rb.AddForce(new Vector3(0, jumpForce, 0));
        grounded = false;
    }
}
