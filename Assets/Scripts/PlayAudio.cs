using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {

    }

    void Update()
    {
        // Example: Play audio when the Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }
    }
}
