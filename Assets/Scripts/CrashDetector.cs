using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float respawnDelay;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX; // Un campo para arrastrar el audio como objeto

    bool hasCrashed; // Variable de control para una única ejecución

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;

            // Podemos obtener otro script y acceder a sus propiedades y métodos públicos
            FindObjectOfType<PlayerController>().DisableControls();

            // Reproducción de la partícula
            crashEffect.Play();

            // El componente AudioSource reproducirá un audio desde el script.
            // De esta forma, el script almacenará varios audios y el GameObject tendrá un único componente AudioSource.
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene", respawnDelay);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
