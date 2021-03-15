using Assets;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Public Fields
    public Rigidbody rb;
    public float movementSpeed;
    public float jumpForce;
    #endregion

    #region Private Fields
    private bool isGrounded;
    #endregion

    #region Unity Calls

    // Start is called before the first frame update
    void Start()
    {
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
        Vector3 playerInput = this.transform.rotation * new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        this.rb.MovePosition(this.transform.position + playerInput * Time.deltaTime * this.movementSpeed);
    }

    private void Jump()
    {
        this.rb.AddForce(new Vector3(0.0f, 2.0f, 0.0f) * this.jumpForce, ForceMode.Impulse);
    }

    #endregion
}
