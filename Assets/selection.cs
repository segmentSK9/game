using UnityEngine;
public class selection : MonoBehaviour
{  public float horizontalInput;
    public float verticalInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
       transform.Translate(Vector3.forward * verticalInput * Time.deltaTime);
       transform.Translate(-Vector3.right * horizontalInput * Time.deltaTime);
    } 
}
