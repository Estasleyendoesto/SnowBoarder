using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*
        Rigidbody2D:
            Angular Drag: Cantidad de fricción que hay cuando giramos
            Linear  Drag: Lo mismo pero cuando vamos hacia delante y atrás
    */

    [SerializeField] float torqueAmount;
    [SerializeField] float boostSpeed;
    [SerializeField] float baseSpeed;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        // Podemos buscar un componente que pertenece a otro objeto mediante su tipo <T>
        // Del mismo modo, podríamos asociar un script nuestro, ir a CrashDetector.cs para más detalles
        // Solo puede ser usado dentro de Start() o Awake()
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void RotatePlayer()
    {
        /*
            AddTorque() solo funciona si el GameObject tiene como componente Rigidbody. 
            Es una fuerza que hace rotar el objeto en una dirección usando las físicas de Unity. 
            Para hacer rotar en el sentido contrario se debe usar un valor negativo.
        */
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            // AddTorque() rota como Rotate() pero solo al Rigidbody si lo hay.
            rb2d.AddTorque(torqueAmount); 
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Podemos acceder a todas las variables y métodos públicos del componente
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }
}
