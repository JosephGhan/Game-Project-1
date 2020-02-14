using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Edit in Unity")]
    public float speed = 8.0f;
    public Text countText;
    public float jumpForce = 2.0f;
    public Text time;
    public float timer = 0.0f;


    private Rigidbody rb;
    static public int count;
    private Vector3 jump;
    private bool isGrounded;
    private int seconds;
 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        UpdateScore();
    }

    // Update is called once per frame before physics
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        seconds = Convert.ToInt32(timer % 60);
        time.text = "Time: " + seconds.ToString();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Jump();
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            UpdateScore();

            if (count == 12)
            {
                if (seconds < Timer.score)
                {
                    Timer.score = seconds;
                }
            }
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void UpdateScore()
    {
        countText.text = "Count: " + count.ToString();
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}
