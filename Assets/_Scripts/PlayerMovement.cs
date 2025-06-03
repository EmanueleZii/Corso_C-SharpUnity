using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector3 movement;

    //INSTATIATE
    [SerializeField] private GameObject cubePrefab; 
    [SerializeField] private Vector3 spawnPosition = new Vector3(0, 1, 0);


    private void FixedUpdate()
    {
        movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) movement += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) movement += Vector3.back;
        if (Input.GetKey(KeyCode.A)) movement += Vector3.left;
        if (Input.GetKey(KeyCode.D)) movement += Vector3.right;

        movement = movement.normalized * speed * Time.fixedDeltaTime;

        // Applichiamo il movimento
        transform.position += movement;

        // Debug info (facoltativo)
        Debug.Log($"Local Pos: {transform.localPosition} | World Pos: {transform.position}");
        if (Input.GetKey(KeyCode.Space))
            Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
    }
}