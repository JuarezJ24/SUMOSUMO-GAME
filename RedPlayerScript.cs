using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RedPlayerScript : MonoBehaviour
{
    public float movementForce;
    public GameObject BluePlayer;
    public GameObject winTextObject;
    public GameObject loseText;
    public GameObject resetButton;
    public GameObject nextButton;
    public TextMeshProUGUI countText;

    private Rigidbody rb;
    private bool gameWon;
    private int count;

   // [SerializeField] 
  //  private Transform RedPlayer;
   
    public GameObject respawnPoint;
   
    public GameObject bluePlayerGameObject;
    public GameObject redSpectatorGO;
    private RedSpectatorScript redSpect;
    private BluePlayerScript bluePlayer;


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
        bluePlayer = bluePlayerGameObject.GetComponent<BluePlayerScript>();
        redSpect = redSpectatorGO.GetComponent<RedSpectatorScript>();

    }
    
    void SetCountText()
    {
        countText.text = "Blue Count: " + count.ToString();
        if (count >= 3)
        {
            winTextObject.SetActive(true);
            nextButton.SetActive(true);
            loseText.SetActive(true);
            gameObject.SetActive(false);
            bluePlayerGameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("RedHorizontal");
        float movementY = Input.GetAxis("RedVertical");
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * movementForce * Time.deltaTime);
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("deadly"))
        {
            Respawn();
            bluePlayer.Respawn();
            count = count + 1;
            SetCountText();
            redSpect.Jump();

        }
    }
    public void Respawn()
    {
       // yield return new WaitForSeconds(0.1f);
        transform.position = respawnPoint.transform.position;
        rb.velocity = Vector3.zero;
    }
}

