using Unity.VisualScripting;
using UnityEngine;

[]
enum tasti
{
    w,
    s,
    a,
    d
}

public class PlayerMovement : MonoBehaviour{
    [SerializeField] private float speed = 5.00f;

    void Update() {
        if (Input.GetKey(tasti.w.ToString()))
            transform.Translate(0f, 0f, speed*Time.deltaTime);
    }
}
