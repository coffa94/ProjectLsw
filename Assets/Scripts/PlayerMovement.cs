using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speedMovement=0.1f;
    [SerializeField] private float scaleCharacter = 0.2f;

    private Rigidbody2D _rigidbody2D; //rigidbody2D component
    private Animator _animator; //player's animator component

   
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        int forwardSidePlayer = 1;

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //horizontal player's movement
        if (horizontal != 0f) {
            _rigidbody2D.velocity = new Vector2(horizontal * Time.deltaTime * speedMovement * forwardSidePlayer, _rigidbody2D.velocity.y);
            if (horizontal < 0f) {
                //forwardSide = left
                forwardSidePlayer = -1;
            } else {
                //forwardSide = right
                forwardSidePlayer = 1;
            }

            //set the right direction of the player
            transform.localScale = new Vector3(forwardSidePlayer * scaleCharacter, scaleCharacter, scaleCharacter);
        }

        //vertical player's movement
        if (vertical != 0f) {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, vertical * Time.deltaTime * speedMovement);
            
        }

        //set animator's parameter speedMovement to start walking animation
        _animator.SetFloat("speedMovement", Mathf.Abs(horizontal) + Mathf.Abs(vertical));
    }
}
