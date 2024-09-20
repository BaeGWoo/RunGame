using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject rotateObject;
    void Start()
    {
      
    }

    private void OnEnable()
    {
        rotateObject = GameObject.Find("RotateManager");
        speed = rotateObject.GetComponent<RotateManager>().Speed;
       
        transform.localRotation = rotateObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed * Time.deltaTime, 0);
        //transform.rotation=new Quaternion(0,GameObject.Find("RotateManager").transform.rotation.y, 0,1);
    }
}
