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
        updateYawPitch();
        followMouse();
        
        defineMovementAlongX();
        defineMovementAlongY();
        defineMovementAlongZ();
    }


    private void FixedUpdate()
    {
        movePlayerAlongX();
        movePlayerAlongY();
        movePlayerAlongZ();
    }
    
    
    private void movePlayer(Vector3 direction)
    {
        _player.MovePosition(_player.transform.position + (direction * _movementSpeed * Time.deltaTime));      
    }
    
    
    private void stopPlayer()
    {
        Vector3 zeroVelocity = new Vector3(0, 0, 0);
        _player.velocity = zeroVelocity;
    }
    
    
    private void updateYawPitch()
    {
        _yaw += _mouseSensitivity * Input.GetAxis(MouseAxisX);
        _pitch -= _mouseSensitivity * Input.GetAxis(MouseAxisY);    
    }
    
    
    private void defineMovementAlongX()
    {
        if (Input.GetKey(RightKey))
            _movementAlongX = MovementsX.RIGHT;
        else if (Input.GetKey(LeftKey))
            _movementAlongX = MovementsX.LEFT;
        else
            _movementAlongX = MovementsX.NONE;
    }
    
    
    private void defineMovementAlongY()
    {
        if (Input.GetKey(UpKey))
            _movementAlongY = MovementsY.UP;
        else if (Input.GetKey(DownKey))
            _movementAlongY = MovementsY.DOWN;
        else
            _movementAlongY = MovementsY.NONE;
    }
    
    
    private void defineMovementAlongZ()
    {
        if (Input.GetKey(ForwardKey))
            _movementAlongZ = MovementsZ.FORWARD;
        else if (Input.GetKey(BackwardKey))
            _movementAlongZ = MovementsZ.BACKWARD;
        else
            _movementAlongZ = MovementsZ.NONE;
    }

    
    
    private void movePlayerAlongX()
    {
        if (_movementAlongX == MovementsX.RIGHT)
            movePlayer(_player.transform.right);
        else if (_movementAlongX == MovementsX.LEFT)
            movePlayer(-_player.transform.right);
        else 
            stopPlayer();
    }
    
    
    private void movePlayerAlongY()
    {
        if (_movementAlongY == MovementsY.UP)
            movePlayer(_player.transform.up);
        else if (_movementAlongY == MovementsY.DOWN)
            movePlayer(-_player.transform.up);
        else 
            stopPlayer();
    }
    
    
    private void movePlayerAlongZ()
    {
        if (_movementAlongZ == MovementsZ.FORWARD)
            movePlayer(_player.transform.forward);
        else if (_movementAlongZ == MovementsZ.BACKWARD)
            movePlayer(-_player.transform.forward);
        else 
            stopPlayer();  
    }
    
    
    private void followMouse()
    {
        _player.transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
    }
}
