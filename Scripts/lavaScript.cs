using UnityEngine;

public class lavaScript : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip soundEffect; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.PlayOneShot(soundEffect);
            other.GetComponent<playercontroller>().Death();
            Debug.Log("player: ouch!");
        }
        if(other.CompareTag("bullet"))
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(soundEffect);
        }
    }
}
