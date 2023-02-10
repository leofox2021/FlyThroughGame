using UnityEngine;
using UnityEngine.UIElements;

// ReSharper disable All

public class UserInterface : MonoBehaviour
{
    [SerializeField] private PlaneMove _plane;
    [SerializeField] private WaypointSpawner _waypointSpawner;
    
    private VisualElement _root;
    
    private Button _startMovementButton;
    private Button _stopMovementButton;
    private Button _newWaypointButton;
    
    private void OnEnable()
    {
        _root = GetComponent<UIDocument>().rootVisualElement;

        _startMovementButton = _root.Q<Button>("StartFlightButton");
        _stopMovementButton = _root.Q<Button>("StopFlightButton");
        _newWaypointButton = _root.Q<Button>("NewWaypointButton");
        
        _startMovementButton.clicked += StartMovementButtonOnclicked;
        _stopMovementButton.clicked += StopMovementButtonOnclicked;
        _newWaypointButton.clicked += NewWaypointButtonOnclicked;
    }
    

    private void StartMovementButtonOnclicked()
    {
        _plane.SetMovingOn();
    }
    
    
    private void StopMovementButtonOnclicked()
    {
        _plane.SetMovingOff();
    }
    
    
    private void NewWaypointButtonOnclicked()
    {
        _waypointSpawner.GenerateWaypoint();
    }
}
