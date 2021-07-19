using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // aqui va a haber que poner una forma de desplazarlo y que combine bien, de momento lo movere tal cual a ver
        transform.Translate(Vector3.left * Time.deltaTime* speed);


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillPlane"))
        {
            Destroy(gameObject);
        }
    }
}
