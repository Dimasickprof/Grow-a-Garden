using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMALE : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] GameObject trirdCamera;
    [SerializeField] GameObject firstCamera;
    [SerializeField] TMP_Text cashText;
    Rigidbody rb;
    [SerializeField] Animator anim;
    Vector3 direction;
    bool isGround = true;
    [SerializeField] int cash = 20;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter(Collision collision)
    {
        isGround = true;
        anim.SetBool("Jump", false);
    }
    // Update is called once per frame
    void Update()
    {
        cashText.text = cash.ToString() + "G$";

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        if(direction.x != 0 || direction.z != 0)
        {
            anim.SetBool("Run",true);
        }
        if(direction.x == 0 && direction.z == 0)
        {
            anim.SetBool("Run",false);
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGround = false;
            anim.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (trirdCamera.activeSelf == true)
            {
                trirdCamera.SetActive(false);
                firstCamera.SetActive(true);
            }
            else
            {
                trirdCamera.SetActive(true);
                firstCamera.SetActive(false);
            }
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
    }
}
