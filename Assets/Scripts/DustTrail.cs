using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrail : MonoBehaviour
{
    // Forma para usar las partículas desde el script
    // Si las partículas forma parte de un objeto (como este caso con el jugador)
    // Se aconseja que sean hijos de este y posición (0,0,0)
    [SerializeField] ParticleSystem dustParticles;

    void OnCollisionEnter2D(Collision2D other)
    {   
        if (other.gameObject.tag == "Ground")
        {
            // Activa las partículas
            dustParticles.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            // Desactiva las partículas
            dustParticles.Stop();
        }   
    }
}
