using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum RoadLine
{
    LEFT=-1,
    MIDDLE,
    RIGHT
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine curState;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float positionX;
    [SerializeField] float speed;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        positionX = 3.5f;
        speed = 10.0f;
    }

    private void OnEnable()
    {
        InputManager.Instance.action += OnKeyUpdate;
    }

    private void OnDisable()
    {
        InputManager.Instance.action -= OnKeyUpdate;
    }

    // Start is called before the first frame update
    void Start()
    {
        curState = RoadLine.MIDDLE;
    }

    void OnKeyUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if ((int)curState > -1)
            {
                curState--;
            }

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if ((int)curState < 1)
            {
                curState++;
            }

        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("Roll");
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }

    }

    private void Move(RoadLine curState)
    {
        Vector3 targetPosition = new Vector3((int)curState * positionX, 0, 0);
        rigidbody.position = Vector3.Lerp(rigidbody.position,targetPosition,speed*Time.fixedDeltaTime);
    }


    

    private void FixedUpdate()
    {
        Move(curState);
    }

    private void OnTriggerEnter(Collider other)
    {

        IColliderable colliderable = other.GetComponent<IColliderable>();

        if (colliderable != null)
        {
            colliderable.Activate();
        }
    }

}
