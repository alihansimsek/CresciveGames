using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    Rigidbody SwordRb;
    private int jumpCount;
    public int doubleJumpLimit = 2;
    public float jumpHeight = 5f;
    public float jumpDistance = 2f;
    private GameController gameController;
    Animator swordRotation;
    // Start is called before the first frame update
    void Start()
    {
        swordRotation = GetComponent<Animator>();
        SwordRb = gameObject.GetComponent<Rigidbody>();
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumpCount < doubleJumpLimit) {
            Jump();
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            SwordRb.useGravity = false;
            SwordRb.velocity = Vector3.zero;
            jumpCount = 0;
                
        }
        if (other.gameObject.tag == "FallPlane")
        {
            gameController.gameOver();
            SwordRb.velocity = Vector3.zero;

        }

    }

    void Jump() {
        SwordRb.velocity = Vector3.zero;
        SwordRb.AddForce(new Vector3(jumpDistance, jumpHeight, 0f), ForceMode.Impulse);
        SwordRb.useGravity = true;
        jumpCount++;
        swordRotation.Play("SwordRotate");

    }
}
