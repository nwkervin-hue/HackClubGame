using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
public class gunScript : MonoBehaviour
{
    private Vector2 mousePos;
    public Camera camera;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed;
    private AudioSource audioSource;
    public AudioClip soundEffect; 
    public List<GameObject> bullets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bullets = new List<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Pointer.current.position.ReadValue());
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            audioSource.PlayOneShot(soundEffect);
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            bullets.Add(bullet);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
        }
    }
    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
