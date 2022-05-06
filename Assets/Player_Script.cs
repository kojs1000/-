using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    public CharacterController controller;
   
    public Vector3 _velocity = new Vector3(1, 1, 0);
    public Vector3 _input = new Vector3(0, 0, 0);
    public float _gravityScale = 1.5f;
    public float _jumpspeed = 1.5f;
    public bool _jumpinputed = false;
    public bool _isGrounded = false;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = controller.isGrounded;
        float dt = Time.deltaTime;
        _input.x = Input.GetAxis("Horizontal");
        //_input.y = Input.GetAxis("Vertical");
        _jumpinputed = Input.GetButtonDown("Jump");
        _velocity = _input;


        if (_isGrounded)
        {

            if (_jumpinputed)
            {
                _velocity.y = _velocity.y + _jumpspeed;
            }

        }
         
        
        
        

        //중력 구현
        _velocity.y =  _velocity.y - (_gravityScale * dt * 9.8f);
        
        
        controller.Move(_velocity);
    }
}
