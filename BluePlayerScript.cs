using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BluePlayerScript : MonoBehaviour
{
    public float movementForce;
    public GameObject RedPlayer;
    public GameObject winTextObject;
    public GameObject loseText;
    public GameObject resetButton;
    public GameObject nextButton;
    public TextMeshProUGUI countText;

    private Rigidbody rb;
    private bool gameWon;
    private int count;

   // [SerializeField] 
   // private Transform BluePlayer;
  
    public GameObject respawnPoint;
   
    public GameObject redPlayerGameObject;
    private RedPlayerScript redPlayer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();

        winTextObject.SetActive(false);
        loseText.SetActive(false);
        resetButton.SetActive(false);
        nextButton.SetActive(false);
        redPlayer = redPlayerGameObject.GetComponent<RedPlayerScript>();
    }
    void SetCountText()
    {
        countText.text = "Red Count: " + count.ToString();
        if (count >= 3)
        {
            winTextObject.SetActive(true);
            nextButton.SetActive(true);
            redPlayerGameObject.SetActive(false);
            loseText.SetActive(true);
            gameObject.SetActive(false);

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        float movementX = Input.GetAxis("BlueHorizontal");
        float movementY = Input.GetAxis("BlueVertical");
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * movementForce * Time.deltaTime);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("deadly"))
        {
            Respawn();
            redPlayer.Respawn();
            count = count + 1;
            SetCountText();

        }
    }

    public void Respawn()
    {
        //yield return new WaitForSeconds(0.1f);
        transform.position = respawnPoint.transform.position;
        rb.velocity = Vector3.zero;
    }

}
