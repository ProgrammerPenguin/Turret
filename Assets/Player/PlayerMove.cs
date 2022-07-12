using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerMoveSpeed = 50f;   
    public float PlayerTurnSpeed = 50f;   

    private PlayerInput _playerInput;
    private Rigidbody _playerRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float accelerationX = PlayerMoveSpeed * _playerInput.X;
        float accelerationZ = PlayerMoveSpeed * _playerInput.Z;

        // _playerrigidbody.AddForce(accelerationX, 0f, accelerationZ); // ���� �ָ� ���� ����ȭ�ȴ�
        _playerRigidbody.velocity = new Vector3(accelerationX, 0f, accelerationZ); // ������ �ӵ��� ���� �ش�.

        if (_playerInput.leftTurn)
        {
            transform.Rotate(0f, -PlayerTurnSpeed, 0f);
        }

        if (_playerInput.rightTurn)
        {
            transform.Rotate(0f, PlayerTurnSpeed, 0f);
        }
    }
}
