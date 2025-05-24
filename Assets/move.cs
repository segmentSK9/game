using UnityEngine;



public class move : MonoBehaviour
{
    public float speed = 6f;          // Vitesse de marche
    public float sprintSpeed = 12f;   // Vitesse de course
    public float jumpSpeed = 8f;
    public float gravity = 20f;
    public float rotationSpeed = 10f;

    private Vector3 moveD = Vector3.zero;
    private CharacterController Cac;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        Cac = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Cac.isGrounded)
        {
            // Détection de l'input vertical
            float verticalInput = Input.GetAxis("Vertical");
            moveD = new Vector3(0, 0, verticalInput);
            moveD = transform.TransformDirection(moveD);

            // Vitesse selon si le joueur court ou marche
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed; // Shift pour courir
            moveD *= currentSpeed;

            // Détecter si le personnage se déplace
            bool ismoving = verticalInput != 0;
            animator.SetBool("ismoving", true);

            // Saut
            if (Input.GetButton("Jump"))
            {
                moveD.y = jumpSpeed;
            }
        }
        else
        {
            animator.SetBool("ismoving", false);
        }

        // Appliquer la gravité
        moveD.y -= gravity * Time.deltaTime;

        // Rotation gauche/droite
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * speed * rotationSpeed);

        // Appliquer le mouvement
        Cac.Move(moveD * Time.deltaTime);
    }
}

