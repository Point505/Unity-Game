using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.SceneManagement;
//Game Play = 0 Gamw Room = 1 Claear = 2 Fail = 3

// H = 속도 감속, H1 = 벽 생성, 
public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] obstacle;
    public bool[] hasobstacle;
    public GameObject[] item;
    public bool[] hasitem;
    public GameObject[] mission;
    public bool[] hasmission;
    private Inventory iv;


    float hAxis;
    float vAxis;

    float time = 5.0f, Jtime = 1.0f;
    int H = 0;

    bool wDown;
    bool jDown;
    bool iDown;

    bool isJump;
    bool isDodge;

    Vector3 moveVec;
    Vector3 dodgeVec;

    Rigidbody rigid;
    Animator anim;

    GameObject nearobject;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        iv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
        anim = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        Debug.Log("StartF");

        speed = 15;
        Debug.Log("StartB");
    }

    void Update()
    {
        GetInput();
        Move();
        Jump();
        Dodge();
        Interation();


        if (H == 1 && time > 0)//지속 시간을 위한 트리거 H=1 time은 5
        {
            time -= Time.deltaTime;
            speed = 3;
        }
        else if (H == 1 && time <= 0)// 트리거가 활성화 됬는데 시간이 종료되었다면
        {
            H = 0;
            time = 5.0f;
            speed = 15;
        }

        if (isJump == true && Jtime > 0)
        {
            Jtime -= Time.deltaTime;
        }
        if (isJump == true && Jtime < 0)
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
        if (isJump == false && Jtime < 0)
            Jtime = 1;

    }

    void GetInput()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        wDown = Input.GetButton("Walk");
        jDown = Input.GetButtonDown("Jump");
        iDown = Input.GetButtonDown("Interation");
    }

    void Move()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        Vector3 moveDirection = forward * Input.GetAxisRaw("Vertical") + right * Input.GetAxisRaw("Horizontal");
        moveVec = moveDirection.normalized;

        if (isDodge)
            moveVec = dodgeVec;

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);


    }


    void Jump()
    {

        if (jDown && moveVec == Vector3.zero && !isJump && !isDodge)
        {
     
            rigid.AddForce(Vector3.up * 5, ForceMode.Impulse);
            anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            isJump = true;

        }
    }

    void Dodge()
    {

        if (jDown && moveVec != Vector3.zero && !isJump && !isDodge)
        {
           
            speed *= 2;
            anim.SetTrigger("doDodge");
            isDodge = true;
            Invoke("DodgeOut", 0.4f);
        }
    }

    void DodgeOut()
    {

        speed *= 0.5f;
        isDodge = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.tag == "Floor")
        //{
        //    anim.SetBool("isJump", false);
        //    isJump = false;
        //    speed = 15;
        //}



        if (collision.collider.gameObject.CompareTag("H1"))
        {
            speed = 3;
          
        }
    }


    void OnCollisionExit(Collision collision)
    {


        if (collision.collider.gameObject.CompareTag("H1"))//H1 에서 탈출하면 
        {
            speed = 15;
       
        }
    }

    void Interation()
    {
        if (iDown && nearobject != null && !isJump && !isDodge)
        {
            if (nearobject.tag == "obstacle")
            {
                obstacle obstacle = nearobject.GetComponent<obstacle>();
                int obstacleIndex = obstacle.value;
                hasobstacle[obstacleIndex] = true;

                Destroy(nearobject);
            }
            if (nearobject.tag == "item")
            {
                item item = nearobject.GetComponent<item>();
                int itemIndex = item.value;
                hasitem[itemIndex] = true;

                Destroy(nearobject);
            }
            if (nearobject.tag == "mission")
            {
                Mission mission = nearobject.GetComponent<Mission>();
                int missionIndex = mission.value;
                hasmission[missionIndex] = true;
                iv.AddMission(mission);

                Destroy(nearobject);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "obstacle")
            nearobject = other.gameObject;
        if (other.tag == "item")
            nearobject = other.gameObject;
        if (other.tag == "mission")
            nearobject = other.gameObject;



    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "obstacle")
            nearobject = null;
        if (other.tag == "item")
            nearobject = null;
        if (other.tag == "mission")
            nearobject = null;


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "H")
        {
            H = 1;

        }


    }


}
