using Unity.VisualScripting;
using UnityEngine;

public class GlassScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundEffect; 
    private BoxCollider2D[] boxColliders;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        boxColliders = GetComponents<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("bullet"))
        {
            Debug.Log("glass: ouch!");
            audioSource.PlayOneShot(soundEffect);
            Destroy(other.gameObject);
            foreach (BoxCollider2D boxCollider in boxColliders)
            {
            if (boxCollider != null)
            {
                boxCollider.enabled = false;
            }
            }
            spriteRenderer.enabled = false;
        }
        
    }
}
