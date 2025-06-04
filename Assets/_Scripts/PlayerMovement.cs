using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Vector3 moveDirection;
    private Vector3 startPosition; 

    void Start()
    {
        moveDirection = Vector3.zero;
        startPosition = transform.position;
    }

    void Update()
    {
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;

        transform.position += moveDirection * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ostacolo"))
        {
            moveDirection = Vector3.zero;
            transform.position = startPosition; 
            Debug.Log("hai perso non sei un campione");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("traguardo"))
        {
            Debug.Log("sei un campione");
        }
    }
}