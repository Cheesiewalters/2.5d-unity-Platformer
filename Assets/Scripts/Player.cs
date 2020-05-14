using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _CharacterController;
    private Vector3 moveDirection = Vector3.zero;
     [SerializeField]
    private UIManager _uiManager;
    [SerializeField]
    private float _speed = 5.0f;
    [SerializeField]
    private float _jumpSpeed = 2.0f;
    [SerializeField]
    private float _gravity = 20.0f;
     [SerializeField]
    private Transform _respawnPoint;
    private bool _canDoubleJump = false;
    private int _lives = 3;

    void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        _uiManager.UpdateLives(_lives);
    }

    void Update()
    {
        if(_CharacterController.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"),0.0f, 0.0f);
            moveDirection *= _speed;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                moveDirection.y = _jumpSpeed;
                _canDoubleJump = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _canDoubleJump == true)
        {
            moveDirection.y += _jumpSpeed;
            _canDoubleJump = false;
        }

        moveDirection.y -= _gravity * Time.deltaTime;
        _CharacterController.Move(moveDirection * Time.deltaTime);
    }

    public void Damage()
    {
        _lives --;
        _uiManager.UpdateLives(_lives);
        if(_lives < 1)
        {
            SceneManager.LoadScene(0);
        }
    }
}
