using UnityEngine;

public class BikeMouseController : MonoBehaviour
{
    public Transform bike;               // Le vélo
    public Transform cameraPivot;        // Un objet vide où est attachée la caméra
    public float moveSpeed = 10f;
    public float rotationSpeed = 3f;
    public float mouseSensitivity = 2f;

    private float yaw = 0f;  // rotation horizontale (gauche/droite)
    private float pitch = 0f; // rotation verticale (haut/bas)

    void Update()
    {
        // Mouvement avant/arrière avec Z/QS/D
        float moveInput = Input.GetAxis("Vertical");
        bike.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // Souris gauche/droite
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;

        // Souris haut/bas (avec clamping pour éviter retournement)
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        pitch = Mathf.Clamp(pitch, -30f, 60f);  // Limite vers le haut et le bas

        // Rotation du joueur (vélo)
        transform.eulerAngles = new Vector3(0f, yaw, 0f);

        // Rotation verticale de la caméra seulement
        if (cameraPivot != null)
        {
            cameraPivot.localEulerAngles = new Vector3(pitch, 0f, 0f);
        }

        // Tourner le vélo avec A/D
        float turnInput = Input.GetAxis("Horizontal");
        bike.Rotate(0f, turnInput * rotationSpeed, 0f);
    }
}
