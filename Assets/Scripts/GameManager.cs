using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D;

public class GameManager : MonoBehaviour
{
    // Referencia al sprite que contiene la imagen para el cursor
    [SerializeField] Texture2D cursorTarget;

    // Referencias a objetos privados visibles desde el Inspector
    [SerializeField] TextMeshProUGUI textoDisparos;
    [SerializeField] TextMeshProUGUI textoMuertes;

    // Variable pública para modificar desde cualquier script
    public int disparos = 0;
    public int muertes = 0;
    // Start is called before the first frame update
    void Start()
    {
        // Configuramos el cursor con el sprite de la mirilla
        Vector2 hotspot = new Vector2(cursorTarget.width / 2, cursorTarget.height / 2);
        Cursor.SetCursor(cursorTarget, hotspot, CursorMode.Auto);
        // Actualizamos la información
        UpdateDisparos();
        UpdateMuertes();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Método público que actualiza el texto de los disparos
    public void UpdateDisparos()
    {
        // Actualizamos el texto de las balas disparadas
        textoDisparos.text = "Disparos: " + disparos;
    }

    public void UpdateMuertes()
    {
        // Actualizamos el texto de los enemigos muertos
        textoMuertes.text = "Enemigos muertos: " + disparos;
    }

}
