using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminationBar : MonoBehaviour
{
    Vector3 movementDir;
    [SerializeField] float position;
    [SerializeField] float speed;

    void Start()
    {
        position = 1;
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        movementDir = new Vector3(0,0f,position).normalized;
        transform.Translate(movementDir*speed*Time.deltaTime, Space.World);
    }

    private void LateUpdate() {
        speed *= 1.0002f;
    }

    void OnTriggerEnter(Collider coll) {
        print("Colision con :" + coll.gameObject.tag);
        if(coll.gameObject.tag == "Player"){
            Time.timeScale = 0; 
            print("Fin del juego");
        } else {
            //Physics.IgnoreCollision(coll, coll);
        }               
    }
}
