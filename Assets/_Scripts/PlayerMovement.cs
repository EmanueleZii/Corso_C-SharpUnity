using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed = 5f;
    public float forceJump = 5f;
    private Vector3 moveDirection;
    private Vector3 startPosition;
    private Rigidbody myrb;
    public bool IsInGround = true;
    void Awake()
    {
        myrb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        moveDirection = Vector3.zero;
        startPosition = transform.position;
        IsInGround = true;
    }
    void Update()
    {
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;

        transform.position += moveDirection * speed * Time.deltaTime;

    
        if (Input.GetKey(KeyCode.Space) && IsInGround)
            myrb.AddForce(Vector3.up * forceJump * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("ostacolo"))
        {
            moveDirection = Vector3.zero;
            transform.position = startPosition;
            Debug.Log("hai perso non sei un campione");
        }
        if (collision.gameObject.CompareTag("Ground"))
            IsInGround = true;
    }
    private void OnCollisionStay(Collision collision)
    { 
        if (collision.gameObject.CompareTag("Ground"))
            IsInGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            IsInGround = false;
    }
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("traguardo"))
            Debug.Log("sei un campione");
    }
}