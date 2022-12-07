using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

  //  Animator _animator;
    Camera _camera;
    Rigidbody _controller;

  //  public float Speed = 5.0f;
  //  public float runSpeed = 8.0f;
  //  public float finalSpeed;
    public bool toggleCameraRotation;
    //  public bool run;
   float time = 0;



   // int count = 0;
    public float smothness = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
  //      _animator = this.GetComponent<Animator>();
        _camera = Camera.main;
        _controller = this.GetComponent<Rigidbody>();
     //   transform.rotation = Quaternion.Euler(-90, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetKey(KeyCode.LeftAlt))
        {
            toggleCameraRotation = true;
        }
        else
        { toggleCameraRotation = false; }

        

      

        //if(Input.GetKey(KeyCode.LeftShift))
        //{
        //    run = true;
        //}
        //else
        //{ run = false; }


        // InputMovement();
    }

   private void LateUpdate()
    {
        if (toggleCameraRotation != true)
        {

            Vector3 playerRotate = Vector3.Scale(_camera.transform.forward, new Vector3(1, 0, 1));

            // Debug.Log(_camera.transform.rotation.eulerAngles);

            /*Debug.Log(playerRotate.y);
            Debug.Log(playerRotate.z);
            Debug.Log(playerRotate.x);
              Debug.Log(transform.rotation.eulerAngles);
            Debug.Log(playerRotate.z);*/
           // transform.rotation = Quaternion.Euler(-90, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerRotate), Time.deltaTime * smothness);
          
        }

    }

//    void InputMovement() {

//        finalSpeed = (run) ? runSpeed : Speed;

//        Vector3 forward = transform.TransformDirection(Vector3.forward);
//        Vector3 right = transform.TransformDirection(Vector3.right);

//        Vector3 moveDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");

//        _controller.Move(moveDirection.normalized * finalSpeed * Time.deltaTime);

//        float percent = ((run) ? 1 : 0.5f) * moveDirection.magnitude;
       
//        _animator.SetFloat("Blend", percent, 0.1f, Time.deltaTime);
//    }
}
