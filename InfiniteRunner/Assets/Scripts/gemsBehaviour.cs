using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemsBehaviour : MonoBehaviour
{
    

    void Start()
    {    }

    void Update()
    {    }

    void OnTriggerEnter(Collider coll) {
        print("Colision con :" + coll.gameObject.name);
        //SUMAR AL MARCADOR SEGUN COLOR DE GEMA
        Destroy(gameObject);
    }

    void sumPoints(GameObject gem) {
        //un switch para saber que gema es

        printPoints();
    }

    void printPoints() {

    }

}
