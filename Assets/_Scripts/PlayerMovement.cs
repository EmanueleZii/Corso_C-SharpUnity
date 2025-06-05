using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float forceJump = 5f;
    private Vector3 moveDirection;
    private Vector3 startPosition;
    [SerializeField]
    private Rigidbody myrb;
    private bool isInGround = true;
    private const float defaultTimerValue = 5f;
    public float timergioco = defaultTimerValue;
    public TextMeshProUGUI textWin;
    public TextMeshProUGUI textTimer;

    private bool isLosing = false;
    private float loseTimer = 3f;

    void Awake()
    {
        myrb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        moveDirection = Vector3.zero;
        startPosition = transform.position;
        timergioco = defaultTimerValue;

        textWin.gameObject.SetActive(false);
        textTimer.text = "";
        Time.timeScale = 1f;
    }

    void Update()
    {
        // Se sta perdendo, gestisci il conto alla rovescia
        bool flowControl = LoseMechanic();
        if (!flowControl){
            return;
        }

        Movement();
        timergioco -= Time.deltaTime;
        textTimer.text = "Tempo: " + timergioco.ToString("F2");
        
    }

    private bool LoseMechanic()
    {
        if (isLosing)
        {
            loseTimer -= Time.unscaledDeltaTime;

            if (loseTimer <= 0f)
            {
                // Reset stato gioco
                transform.position = startPosition;
                timergioco = defaultTimerValue;
                loseTimer = 3f;
                isLosing = false;
                timergioco = 5f;
                textWin.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }

            return false; // Non eseguire il resto di Update mentre in pausa
        }

        return true;
    }

    private void Movement()
    {
        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDirection += Vector3.forward;
        if (Input.GetKey(KeyCode.S)) moveDirection += Vector3.back;
        if (Input.GetKey(KeyCode.A)) moveDirection += Vector3.left;
        if (Input.GetKey(KeyCode.D)) moveDirection += Vector3.right;

        transform.position += moveDirection * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && isInGround)
        {
            myrb.AddForce(Vector3.up * forceJump, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ostacolo"))
        {
            // Attiva la perdita
            isLosing = true;
            Time.timeScale = 0f;
            textWin.gameObject.SetActive(true);
            textWin.text = "You Lose";
        }

        if (collision.gameObject.CompareTag("Ground"))
            isInGround = true;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isInGround = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isInGround = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("traguardo"))
        {
            textWin.gameObject.SetActive(true);
            textWin.text = "You Won!";
            timergioco = defaultTimerValue;
        }
    }
}