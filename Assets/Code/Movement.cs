using static Database.Enums;
using static Database.Keys;
using UnityEngine;

// ReSharper disable All

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _mouseSensitivity;
    
    private MovementsX _movementAlongX = MovementsX.NONE;
    private MovementsY _movementAlongY = MovementsY.NONE;
    private MovementsZ _movementAlongZ = MovementsZ.NONE;
    
    private float _yaw;
    private float _pitch;
    
    
    public void Update()
    {
        updateYawPitch();
        followMouse();
        
        defineMovementAlongX();
        defineMovementAlongY();
        defineMovementAlongZ();
    }


    public void FixedUpdate()
    {
        movePlayerAlongX();
        movePlayerAlongY();
        movePlayerAlongZ();
    }
    
    
    public void movePlayer(Vector3 direction)
    {
        player.MovePosition(player.transform.position + direction * _movementSpeed * Time.deltaTime);      
    }
    
    
    public void stopPlayer()
    {
        Vector3 zeroVelocity = new Vector3(0, 0, 0);
        player.velocity = zeroVelocity;
    }
    
    
    private void updateYawPitch()
    {
        _yaw += _mouseSensitivity * Input.GetAxis(mouseAxisX);
        _pitch -= _mouseSensitivity * Input.GetAxis(mouseAxisY);    
    }
    
    
    private void defineMovementAlongX()
    {
        if (Input.GetKey(rightKey))
            _movementAlongX = MovementsX.RIGHT;
        else if (Input.GetKey(leftKey))
            _movementAlongX = MovementsX.LEFT;
        else
            _movementAlongX = MovementsX.NONE;
    }
    
    
    private void defineMovementAlongY()
    {
        if (Input.GetKey(upkey))
            _movementAlongY = MovementsY.UP;
        else if (Input.GetKey(downKey))
            _movementAlongY = MovementsY.DOWN;
        else
            _movementAlongY = MovementsY.NONE;
    }
    
    
    private void defineMovementAlongZ()
    {
        if (Input.GetKey(forwardKey))
            _movementAlongZ = MovementsZ.FORWARD;
        else if (Input.GetKey(backwardKey))
            _movementAlongZ = MovementsZ.BACKWARD;
        else
            _movementAlongZ = MovementsZ.NONE;
    }

    
    
    private void movePlayerAlongX()
    {
        if (_movementAlongX == MovementsX.RIGHT)
            movePlayer(player.transform.right);
        else if (_movementAlongX == MovementsX.LEFT)
            movePlayer(-player.transform.right);
        else 
            stopPlayer();
    }
    
    
    private void movePlayerAlongY()
    {
        if (_movementAlongY == MovementsY.UP)
            movePlayer(player.transform.up);
        else if (_movementAlongY == MovementsY.DOWN)
            movePlayer(-player.transform.up);
        else 
            stopPlayer();
    }
    
    
    private void movePlayerAlongZ()
    {
        if (_movementAlongZ == MovementsZ.FORWARD)
            movePlayer(player.transform.forward);
        else if (_movementAlongZ == MovementsZ.BACKWARD)
            movePlayer(-player.transform.forward);
        else 
            stopPlayer();  
    }
    
    
    private void followMouse()
    {
        player.transform.eulerAngles = new Vector3(_pitch, _yaw, 0.0f);
    }
}
