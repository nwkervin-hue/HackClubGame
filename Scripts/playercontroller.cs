using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class playercontroller : MonoBehaviour
{
    [SerializeField]
    private gunScript gunScript;
    private Rigidbody2D rb;
    private Vector3 DragStart;
    private bool drag = false;
    private Vector3 startScreenPos;
    private Vector3 screenDelta;
    private Vector2 mousePos;
    public Camera camera;
    private AudioSource audioSource;
    public AudioClip soundEffect; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
 
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            startScreenPos = Pointer.current.position.ReadValue();
            drag = true;
            rb.linearVelocity = Vector2.zero;
            Time.timeScale = 0f;
        }

        // 2. Continuous drag
        if (drag && Mouse.current.leftButton.isPressed)
        {
            Vector3 currentScreenPos = Pointer.current.position.ReadValue();
            screenDelta = currentScreenPos - startScreenPos;
        }

        // 3. Release
        if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            drag = false;
            Time.timeScale = 1f; 
            rb.AddForce(screenDelta * 3f);
        }
    }
    private void FixedUpdate() {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("wall"))
        {
            audioSource.PlayOneShot(soundEffect);
            Debug.Log("player: boing");
        }
    }
    public void Death()
    {
        foreach (GameObject bullet in gunScript.bullets)
        {
            if (bullet != null)
            {
                Destroy(bullet);
            }
        }
        transform.position = new Vector3(0, 2, 0);
        rb.linearVelocity = new Vector2(0, 2);
    }
}
