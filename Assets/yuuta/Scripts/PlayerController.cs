using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerStatusController status;
    private float moveSpeed;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        status = GetComponent<PlayerStatusController>();

        if (rb == null) Debug.LogError("Rigidbody2D‚ª‚ ‚è‚Ü‚¹‚ñ", this);
        if (status == null) Debug.LogError("PlayerStatusController‚ª‚ ‚è‚Ü‚¹‚ñ", this);
    }

    void Start()
    {
        moveSpeed = status.Speed;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        moveInput = new Vector2(
                (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0),
                (Keyboard.current.wKey.isPressed ? 1 : 0) - (Keyboard.current.sKey.isPressed ? 1 : 0)
              ).normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
}