using UnityEngine;

public class BikeController : MonoBehaviour
{
    public Transform bike;               // Le modèle du vélo
    public float moveSpeed = 10f;
    public float rotationSpeed = 90f;

    void Update()
    {
        // Mouvement avant/arrière
        float moveInput = Input.GetAxis("Vertical");
        bike.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);

        // Rotation gauche/droite
        float turnInput = Input.GetAxis("Horizontal");
        bike.Rotate(0f, turnInput * rotationSpeed * Time.deltaTime, 0f);
    }
}