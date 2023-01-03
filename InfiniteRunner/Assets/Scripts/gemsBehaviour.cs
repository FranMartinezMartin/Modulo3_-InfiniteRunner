using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemsBehaviour : MonoBehaviour
{
    
    private string gemType;

    void Start()
    {  
        gemType = transform.name;
    }

    void Update()
    {    }

    void OnTriggerEnter(Collider coll) {
        //SUMAR AL MARCADOR SEGUN COLOR DE GEMA     
        if(coll.gameObject.tag == "Player") {
            switch(gemType) {
            case "Diamond Yellow":
                print("Diamante amarillo = +1pts");
            break;
            case "Diamond Blue":
                print("Diamante amarillo = +5pts");
            break;
            case "Diamond Green":
                print("Diamante amarillo = +10pts");
            break;
            }
        } else if(coll.gameObject.tag == "elimination_bar") {
            Destroy(gameObject);
        }        
    }

    void sumPoints(GameObject gem) {
        //un switch para saber que gema es

        printPoints();
    }

    void printPoints() {
    }

}
