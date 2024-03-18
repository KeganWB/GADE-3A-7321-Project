using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    private Vector3 _playerVelocity;
    public float _speed = 5f;
    private bool IsGrounded;
    public float _gravity = -9.8f;
    public float _jumpHeight = 3f;
    private bool _carryingBlueFlag = false;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        IsGrounded = _controller.isGrounded;

        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move(input);
    }

    public void Move(Vector2 input)
    {
        Vector3 moveDirection = new Vector3(input.x, 0, input.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= _speed * Time.deltaTime;

        if (IsGrounded)
        {
            _playerVelocity.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                _playerVelocity.y = Mathf.Sqrt(-2f * _gravity * 1.5f);
            }
        }

        _playerVelocity.y += _gravity * Time.deltaTime;
        moveDirection += _playerVelocity * Time.deltaTime;
        _controller.Move(moveDirection);
    }

    public void Jump()
    {
        if (IsGrounded)
        {
            _playerVelocity.y = Mathf.Sqrt(_jumpHeight * -3f * _gravity);
        }
    }

    public void CarryBlueFlag()
    {
        _carryingBlueFlag = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("RedFlagBase") && _carryingBlueFlag)
        {
            GameManager.Instance.PlayerReturnedBlueFlagAtBase();
            _carryingBlueFlag = false;
        }
    }
}
