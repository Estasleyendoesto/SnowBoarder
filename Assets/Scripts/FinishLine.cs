using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // new...

/*
    Para cargar las escenas debemos ir a File → Build Settings → Add Open Scenes 
    entonces están disponibles para ser usadas desde el código. 
    Pulsando Supr eliminamos la escena seleccionada y si observamos en el 
    extremo derecho de cada escena hay un número asociado que es el índice.
*/

public class FinishLine : MonoBehaviour
{
    [SerializeField] float respawnDelay;
    [SerializeField] ParticleSystem finishEffect;

    bool hasArrived;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !hasArrived)
        {
            hasArrived = true;
            finishEffect.Play();

            // Forma easy para reproducir un audio.
            // Si son varios audios usar GetComponents en su lugar y tratarlo como un array:
            //  - GetComponents<AudioSource>()[0].Play()
            // Aunque existe un mejor método de tratar varios audio en un solo GameObject, ver CrashDetector.cs
            GetComponent<AudioSource>().Play();

            // Invoke, alternativa más simple que Coroutines
            // Invoca un método tras un tiempo de espera (en segundos).
            Invoke("ReloadScene", respawnDelay);
        }
    }

    void ReloadScene()
    {
        // Para acceder a la configuración de escenas desde el código debemos importar SceneManagement
        SceneManager.LoadScene(0);
    }
}
