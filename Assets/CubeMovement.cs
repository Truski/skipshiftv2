using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed = 8f;
    public float rotationSpeed = 150f;
    public float jumpForce = 4f;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        setIsGrounded(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 m_Input = transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.MovePosition(transform.position + m_Input * Time.deltaTime * movementSpeed);

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSpeed);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            setIsGrounded(true);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            setIsGrounded(false);
        }
    }

    private void Jump()
    {
        rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * jumpForce, ForceMode.Impulse);
    }

    private void setIsGrounded(bool grounded)
    {
        isGrounded = grounded;
    }
}
