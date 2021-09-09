using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    private string currentState;

    private Rigidbody2D m_Rigidbody2D;

    bool jump = false;
    bool crouch = false;


    const string PLAYER_Idle = "Idlke_player";
    const string PLAYER_Run = "Terrowin_Run";
    const string PLAYER_Jump = "Player_Jump";
    const string PLAYER_Hurt = "Player_hurt";
    const string PLAYER_Attack = "Player_Attack";


    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void start()
    {
        animator = GetComponent<Animator>();
    }

    void ChangeanimationState(string newState)
    {
        if (currentState == newState) return;

        animator.Play(newState);

        currentState = newState;
    }


    //   Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (m_Rigidbody2D.velocity.y == 0f && controller.m_Grounded==true)
        {
            
            if (horizontalMove == 0)
            {
                ChangeanimationState(PLAYER_Idle);
            }
            else if (horizontalMove != 0)
            {
                ChangeanimationState(PLAYER_Run);
            }
        }

        else if (m_Rigidbody2D.velocity.y != 0f&& controller.m_Grounded==false)
        {
            ChangeanimationState(PLAYER_Jump);
                //if (jump == true)
                //{
                
        }
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    public void OnLanding()
    {
        
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);//Move our character
        jump = false;
        Debug.Log(Time.time);
    }
}