using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IColliderable
{
    [SerializeField] float speed;
    [SerializeField] GameObject rotateObject;

    [SerializeField] ParticleSystem particleSystem;

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

    public void Activate()
    {
        if (!GetComponent<MeshRenderer>().enabled)
            return;


        particleSystem.gameObject.SetActive(true);
        GetComponent<MeshRenderer>().enabled = false;
        particleSystem.Play();
    }
}
