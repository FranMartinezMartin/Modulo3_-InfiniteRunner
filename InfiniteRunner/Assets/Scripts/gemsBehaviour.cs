using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemsBehaviour : MonoBehaviour
{
    
    [SerializeField] Camera mainCamera;

    void Start()
    {  
        mainCamera = Camera.main;
    }

    void Update()
    {    }

    void OnTriggerEnter(Collider coll) {
        //SUMAR AL MARCADOR SEGUN COLOR DE GEMA     
        if(coll.CompareTag("Player")) {
            switch(transform.tag) {
            case "YELLOW_D":
                mainCamera.GetComponent<Score>().yellowDiamondSum();
                Destroy(gameObject);
                break;
            case "BLUE_D":
                mainCamera.GetComponent<Score>().blueDiamondSum();
                Destroy(gameObject);
                break;
            case "GREEN_D":
                mainCamera.GetComponent<Score>().greenDiamondSum();
                Destroy(gameObject);
                break;
            }      
        } else if(coll.gameObject.tag == "elimination_bar") {
            Destroy(gameObject);
            // CUANDO TERMINE EL JUEGO SE DEBE CARGAR PRINCIPAL CON MENSAJE DEL RESULTADO
        }        
    }
}
