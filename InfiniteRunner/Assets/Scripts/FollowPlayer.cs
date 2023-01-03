using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(0,5.73f,player.transform.position.z - 4.06f);       
    }
}
