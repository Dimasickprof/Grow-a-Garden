using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMALE : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float jumpForce = 7f;
    Rigidbody rb;
    Vector3 direction;
    bool isGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        isGround = true;
    }
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGround = false;
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * movementSpeed * Time.deltaTime);
    }
}
