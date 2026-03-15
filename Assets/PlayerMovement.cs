using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    void Update()
    {
        // Obtener inputs de los ejes clásicos (Horizontal y Vertical)
        float x = Input.GetAxis("Horizontal"); // A, D
        float z = Input.GetAxis("Vertical");   // W, S

        // Calcular dirección relativa a hacia donde mira el jugador
        Vector3 move = transform.right * x + transform.forward * z;

        // Mover al jugador
        controller.Move(move * speed * Time.deltaTime);

        // Aplicar gravedad simple
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}