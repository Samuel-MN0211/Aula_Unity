using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0f)] float speed = 5f; // m/s

    Rigidbody rb;
    InputAction move;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        // Ação "Player/Move" do InputSystem_Actions (ações globais do projeto)
        move = InputSystem.actions.FindAction("Player/Move", throwIfNotFound: true);
    }

    void OnEnable() => move?.Enable();

    void FixedUpdate()
    {
        Vector2 input = Vector2.ClampMagnitude(move.ReadValue<Vector2>(), 1f);
        Vector3 v = new Vector3(input.x, 0f, input.y) * speed;
        v.y = rb.linearVelocity.y; // mantém a gravidade
        rb.linearVelocity = v;
    }
}
