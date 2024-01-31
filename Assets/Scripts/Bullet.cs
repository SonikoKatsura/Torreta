using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    // Al generarse cada bala se incrementa la cuenta y se actualiza el texto
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().disparos++;
        GameObject.Find("GameManager").GetComponent<GameManager>().UpdateDisparos();
    }



    // Update is called once per frame
    void Update()
    {
        
    }
    // Cuando las balas salen de la escena se autodestruyen
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
