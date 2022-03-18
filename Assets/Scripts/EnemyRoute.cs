using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRoute : MonoBehaviour
{

    Transform target;
    NavMeshAgent agente;
    int indiceDeRuta;

    public Transform [] puntosDeRuta;
    

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("jugador").transform;
        agente = GetComponent <NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position)<5)
        {
            agente.destination = target.position;
            Debug.Log("Ahi estas");
            if(Vector3.Distance(transform.position, target.position)<2)
            {
                Debug.Log("Parecen Fuegos de Artificio");
            } else 
            {
                Debug.Log("¡Rayos y retuecanos! ¡se me a escapado!");
            }
        } else
            {
                agente.destination = puntosDeRuta[indiceDeRuta].position;
            }

        if(Vector3.Distance(transform.position, puntosDeRuta[indiceDeRuta].position) <0.5f)
        {
            if(indiceDeRuta < puntosDeRuta.Length-1)
            {
                indiceDeRuta++;
                Debug.Log("Punto de ruta alcanzado");
            } else
            {
                indiceDeRuta = 0;
            }
        }
    }
}
