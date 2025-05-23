using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 6f;
    public float jumpSpeed = 8f;
    public float gravity = 20f; // POSITIF maintenant

    private Vector3 moveD = Vector3.zero;
    private CharacterController Cac;

    void Start()
    {
        Cac = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Cac.isGrounded)
        {
            // Mouvement avant/arrière
            moveD = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveD = transform.TransformDirection(moveD);
            moveD *= speed;

            // Saut
            if (Input.GetButton("Jump"))
            {
                moveD.y = jumpSpeed;
            }
        }

        // Appliquer la gravité
        moveD.y -= gravity * Time.deltaTime;

        // Rotation gauche/droite
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * speed * 10);

        // Appliquer le mouvement
        Cac.Move(moveD * Time.deltaTime);
    }
}
