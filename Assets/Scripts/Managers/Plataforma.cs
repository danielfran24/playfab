using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 3;
    public Transform[] spawnsTierra;
    public Transform[] spawnsAire;
    public GameObject[] spawnOptionsAire;
    public GameObject[] spawnOptionsTierra;

    private float heightDifference = 4f;
    public float spawnProbability = 0.5f;

    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        // aqui va a haber que poner una forma de desplazarlo y que combine bien, de momento lo movere tal cual a ver
        transform.Translate(Vector3.left * Time.deltaTime* speed);


    }

    private void Spawn()
    {


        foreach(Transform pos in spawnsTierra)
        {
            if(Random.value < spawnProbability)
            {
                Instantiate(spawnOptionsTierra[Random.Range(0, spawnOptionsTierra.Length)], pos.position, Quaternion.identity,gameObject.transform);

            }

        }

        foreach(Transform pos in spawnsAire)
        {
            if(Random.value < spawnProbability)
            {
                Instantiate(spawnOptionsAire[Random.Range(0, spawnOptionsAire.Length)], pos.position + new Vector3(0, Random.Range(0f, heightDifference), 0), Quaternion.identity,gameObject.transform);
            }
        }





    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillPlane"))
        {
            Destroy(gameObject);
        }
    }
}
