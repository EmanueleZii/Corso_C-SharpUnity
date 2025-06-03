using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [SerializeField] private float speed = 5.00f;

    void Update() {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(0f, 0f, speed*Time.deltaTime);
    }
}
