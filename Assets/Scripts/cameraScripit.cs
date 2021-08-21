using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScripit : MonoBehaviour
{
 
    private bool bounds = true;
    [SerializeField] float speed = 5f;
    [SerializeField] Transform playerTrans;

    void Start()
    {
        playerTrans = GameObject.Find("Player").GetComponent<Transform>();
    }

    void LateUpdate()
    {
        transform.position = Vector3.Slerp(transform.position,
                              new Vector3(playerTrans.position.x, transform.position.y, transform.position.z),
                              speed);
    }

   
}