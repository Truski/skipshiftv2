using Assets;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Public Fields
    public Rigidbody rb;
    public float movementSpeed;
    public float jumpForce;
    public Camera camera;
    #endregion

    #region Private Fields
    private bool isGrounded;
    #endregion

    #region Unity Calls

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isGrounded = false;
    }

    // Fixed update runs per the set physics interval for the project
    void FixedUpdate()
    {
        Move();
    }

    // Update runs once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == Constants.GameTags.Floor)
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == Constants.GameTags.Floor)
        {
            isGrounded = false;
        }
    }

    #endregion

    #region Private Methods

    private void Move()
    {
        Vector3 playerInput = this.camera.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        this.transform.Translate(playerInput * Time.deltaTime * this.movementSpeed, Space.World);

        if (playerInput.x != 0 && playerInput.y != 0)
        {
            this.transform.rotation = Quaternion.LookRotation(playerInput);
        }
    }

    private void Jump()
    {
        this.rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * this.jumpForce, ForceMode.Impulse);
    }

    #endregion
}
