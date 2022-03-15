using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float Jump = 700;

    public bool isOnGround = true;
    public float currSpeed = 5;
    public float baseSpeed = 5;
    public float MaxSpeed = 15;

    public bool  runJump = false;
    public bool  moveJump = false;
    private Animator playerAnimator;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();

    }

    void CalculatSpeed()
    {
        currSpeed = Mathf.Lerp(currSpeed, MaxSpeed, 0.001f);
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && runJump == true && moveJump == true)
        {
            playerRB.AddForce(Vector3.up * Jump, ForceMode.Impulse);
            // transform.Translate(Vector3.up * Jump);
            isOnGround = false;
            playerAnimator.SetBool("Jump", true);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
        }



        if (Input.GetKey(KeyCode.UpArrow))
        {
            CalculatSpeed();
            transform.Translate(Vector3.forward * currSpeed * Time.deltaTime);
            playerAnimator.SetBool("idle-move", true);
            playerAnimator.SetFloat("move-run", currSpeed);
            runJump = true;
            moveJump = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            // CalculatSpeed();
            transform.Translate(-Vector3.forward * currSpeed * Time.deltaTime);
            playerAnimator.SetBool("idle-move", true);
            // playerAnimator.SetFloat("move-run", currSpeed);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * currSpeed * Time.deltaTime);
            playerAnimator.SetBool("idle-move", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-Vector3.right * currSpeed * Time.deltaTime);
            playerAnimator.SetBool("idle-move", true);
        }
        else
        {
            playerAnimator.SetBool("idle-move", false);
            currSpeed = baseSpeed;
            playerAnimator.SetFloat("move-run", currSpeed);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        if (collision.gameObject.CompareTag("Cube"))
        {
            playerAnimator.SetBool("Falling-forward", true);
        }
        else
        {
            playerAnimator.SetBool("Falling-forward", false);
        }
        if (collision.gameObject.CompareTag("CubeBig"))
        {
            playerAnimator.SetBool("Falling-back", true);
        }
        else
        {
            playerAnimator.SetBool("Falling-back", false);
        }
    }
}






















































// //float HoriInput = Input.GetAxisRaw("Horizontal") * baseSpeed;
//         // playerAnimator.SetBool("move", true);
//         ;
//         float VertiInput = Input.GetAxisRaw("Vertical");

//         if (VertiInput != 0)
//         {
//             if (currSpeed == 0)
//             {
//                 currSpeed = baseSpeed * VertiInput;
//             }
//             // Debug.Log("Play move: " + VertiInput);
//             currSpeed += Time.deltaTime * VertiInput;
//             currSpeed = Mathf.Clamp(currSpeed, -MaxSpeed, MaxSpeed);

//         }
//         else
//         {
//             if (currSpeed < -baseSpeed) // trang thai lui 
//             {
//                 currSpeed += Time.deltaTime;
//                 currSpeed = Mathf.Clamp(currSpeed, -MaxSpeed, -baseSpeed);
//             }
//             else if (currSpeed > 0)
//             {
//                 currSpeed -= Time.deltaTime;
//                 currSpeed = Mathf.Clamp(currSpeed, 0, MaxSpeed);
//             }
//             //Mathf.Infinity
//             {
//                 if (currSpeed > baseSpeed)
//                 {
//                     currSpeed -= Time.deltaTime;
//                     currSpeed = Mathf.Clamp(currSpeed, baseSpeed, MaxSpeed);
//                 }
//                 else if (currSpeed < 0)
//                 {
//                     currSpeed += Time.deltaTime;
//                     currSpeed = Mathf.Clamp(currSpeed, -MaxSpeed, 0);
//                 }
//                 //Mathf.Infinity
//             }
//         }
//         transform.Translate(0, 0, currSpeed * Time.deltaTime);
//         transform.Translate(0, HoriInput * Time.deltaTime, 0);