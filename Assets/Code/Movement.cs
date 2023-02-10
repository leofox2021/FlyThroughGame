using static Database.Enums;
using static Database.Keys;
using UnityEngine;

// ReSharper disable All

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody _player;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _mouseSensitivity;
    
    private MovementsX _movementAlongX = MovementsX.NONE;
    private MovementsY _movementAlongY = MovementsY.NONE;
    private MovementsZ _movementAlongZ = MovementsZ.NONE;
    
    private float _yaw;
    private float _pitch;
    
    
    private void Update()
    {
        UpdateYawPitch();
        FollowMouse();
        
        DefineMovementAlongX();
        DefineMovementAlongY();
        DefineMovementAlongZ();
    }


    private void FixedUpdate()
    {
        MovePlayerAlongX();
        MovePlayerAlongY();
        MovePlayerAlongZ();
    }
    
    
    private void MovePlayer(Vector3 direction)
    {
        _player.MovePosition(_player.transform.position + (direction * _movementSpeed * Time.deltaTime));      
    }
    
    
    private void StopPlayer()
    {
        Vector3 zeroVelocity = new Vector3(0, 0, 0);
        _player.velocity = zeroVelocity;
    }
    
    
    private void UpdateYawPitch()
    {
        _yaw += _mouseSensitivity * Input.GetAxis(MouseAxisX);
        _pitch -= _mouseSensitivity * Input.GetAxis(MouseAxisY);    
    }
    
    
    private void DefineMovementAlongX()
    {
        if (Input.GetKey(RightKey))
            _movementAlongX = MovementsX.RIGHT;
        else if (Input.GetKey(LeftKey))
            _movementAlongX = MovementsX.LEFT;
        else
            _movementAlongX = MovementsX.NONE;
    }
    
    
    private void DefineMovementAlongY()
    {
        if (Input.GetKey(UpKey))
            _movementAlongY = MovementsY.UP;
        else if (Input.GetKey(DownKey))
            _movementAlongY = MovementsY.DOWN;
        else
            _movementAlongY = MovementsY.NONE;
    }
    
    
    private void DefineMovementAlongZ()
    {
        if (Input.GetKey(ForwardKey))
            _movementAlongZ = MovementsZ.FORWARD;
        else if (Input.GetKey(BackwardKey))
            _movementAlongZ = MovementsZ.BACKWARD;
        else
            _movementAlongZ = MovementsZ.NONE;
    }

    
    
    private void MovePlayerAlongX()
    {
        if (_movementAlongX == MovementsX.RIGHT)
            MovePlayer(_player.transform.right);
        else if (_movementAlongX == MovementsX.LEFT)
            MovePlayer(-_player.transform.right);
        else 
            StopPlayer();
    }
    
    
    private void MovePlayerAlongY()
    {
        if (_movementAlongY == MovementsY.UP)
            MovePlayer(_player.transform.up);
        else if (_movementAlongY == MovementsY.DOWN)
            MovePlayer(-_player.transform.up);
        else 
            StopPlayer();
    }
    
    
    private void MovePlayerAlongZ()
    {
        if (_movementAlongZ == MovementsZ.FORWARD)
            MovePlayer(_player.transform.forward);
        else if (_movementAlongZ == MovementsZ.BACKWARD)
            MovePlayer(-_player.transform.forward);
        else 
            StopPlayer();  
    }
    
    
    private void FollowMouse()
    {
        _player.transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
    }
}
