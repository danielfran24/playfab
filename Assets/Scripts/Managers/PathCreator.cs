using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathCreator : MonoBehaviour
{
    // Start is called before the first frame update

    public float offset;

    public GameObject[] Paths;

    public float velocidadActual;

    public float velocidadSumada;

    void Start()
    {
        velocidadActual = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if(!(velocidadActual >= 6.7f)){

            velocidadActual += velocidadSumada;

        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            CrearPath();        
        }
    }

    private void CrearPath()
    {
        Debug.Log("heyyy");

        Instantiate(Paths[Random.Range(0, Paths.Length)],( this.transform.position+ new Vector3(offset,0,0)), Quaternion.identity).GetComponent<Plataforma>().speed = velocidadActual;


        
    }
}
