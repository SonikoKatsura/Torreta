using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBallMotion : MonoBehaviour
{
    // Variable privada accesible desde el inspector para configurar
    // el tiempo de vida de la trampa (en segundos)
    [SerializeField] float lifeSpan = 5f;

    // Variable privada para contabilizar el tiempo total que ha pasado
    // desde que se generó la instancia de la trampa
    private float time;

    // Variable privada accesible desde el inspector para configurar
    // la fuerza con la que se generan los movimientos circulares
    [SerializeField] float rotationForce = 30f;


    // Referencia privada al objeto ForcePoint
    GameObject forcePointRef;

    void Start()
    {
        // Obtenemos la referencia al objeto sobre el
        // que se aplicará la fuerza
        forcePointRef = GameObject.Find("ForcePoint");
    }

   void Update() {
        // Aplica una fuerza en la dirección local que apunta a la derecha (como al
        // cambiar la rotación la dirección también lo hace, funcionará perfectamente)
        forcePointRef.GetComponent<Rigidbody2D>().velocity = forcePointRef.transform.right * rotationForce;

        // Obtenemos el tiempo que ha pasado desde el anterior
        // frame y lo vamos acumulando en la variable time
        time += Time.deltaTime;

    // Comprobamos si se ha alcanzado el tiempo de vida y si lo hizo se
    // destruirá el gameObject de la trampa
    if (time >= lifeSpan) Destroy(gameObject);
}



}
