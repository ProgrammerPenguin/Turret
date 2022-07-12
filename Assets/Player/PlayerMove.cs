using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody _playerrigidbody;
    public float playerSpeed;   
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerrigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float accelerationX = playerSpeed * _playerInput.X;
        float accelerationZ = playerSpeed * _playerInput.Z;

        _playerrigidbody.AddForce(accelerationX, 0f, accelerationZ);
    }
}
