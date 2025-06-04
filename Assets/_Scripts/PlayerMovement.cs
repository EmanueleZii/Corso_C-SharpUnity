using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += Vector3.forward; // avanti
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += Vector3.back; // indietro
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += Vector3.left; // sinistra
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += Vector3.right; // destra
        }

        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portale"))
        {
            speed *= 1;
            Debug.Log("Collide!");
        }
    }
}
