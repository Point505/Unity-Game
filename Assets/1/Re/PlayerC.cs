using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;


public class PlayerC : MonoBehaviour
{
    public float speed;
    public GameObject[] obstacle;
    public bool[] hasobstacle;
    public GameObject[] item;
    public bool[] hasitem;
    public GameObject[] mission;
    public bool[] hasmission;
    private Inventory Iv;

    float hAxis;
    float vAxis;
    //float moveSpeed;

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
        anim = GetComponentInChildren<Animator>();
        Iv = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }

    void Update()
    {
        GetInput();
        Move();
        Turn();
        Jump();
        Dodge();
        Interation();
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
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (isDodge)
            moveVec = dodgeVec;

        transform.position += moveVec * speed * (wDown ? 0.3f : 1f) * Time.deltaTime;

        anim.SetBool("isRun", moveVec != Vector3.zero);
        anim.SetBool("isWalk", wDown);
    }

    void Turn()
    {
        transform.LookAt(transform.position + moveVec);
    }

    void Jump()
    {
        if(jDown && moveVec == Vector3.zero && !isJump && !isDodge)
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
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
        if (collision.gameObject.tag == "Floor")
        {
            anim.SetBool("isJump", false);
            isJump = false;
        }
    }

    void Interation()
    {
        if (iDown && nearobject != null && !isJump && !isDodge)
        {
            //if (nearobject.tag == "obstacle")
            //{
            //    obstacle obstacle = nearobject.GetComponent<obstacle>();
            //    int obstacleIndex = obstacle.value;
            //    hasobstacle[obstacleIndex] = true;

            //    Destroy(nearobject);
            //}
            //if (nearobject.tag == "item")
            //{
            //    item item = nearobject.GetComponent<item>();
            //    int itemIndex = item.value;
            //    hasitem[itemIndex] = true;

            //    Destroy(nearobject);
            //}
            if (nearobject.tag == "mission")
            {
                Mission mission = nearobject.GetComponent<Mission>();
                int missionIndex = mission.value;
                hasmission[missionIndex] = true;
                Iv.AddMission(mission);
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

        //Debug.Log(nearobject.name);
    }
    //void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "obstacle")
    //        nearobject = null;
    //    if (other.tag == "item")
    //        nearobject = null;
    //    if (other.tag == "mission")
    //        nearobject = null;
    //}

    //public void SetMoveSpeed(float speed)
    //{
    //    Vector3 getVel = new Vector3(1, 0, 1) * speed;
    //    rigid.velocity = getVel;
    //}

    //public  Vector3 getMoveSpeed()
    //{
    //    return rigid.velocity; // Velocity of gameObject (Vector3)
    //    return moveSpeed;
    //}

}
