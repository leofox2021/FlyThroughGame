using UnityEngine;
using UnityEngine.UIElements;

// ReSharper disable All

public class UserInterface : MonoBehaviour
{
    [SerializeField] private PlaneMove plane;
    [SerializeField] private WaypointSpawner waypointSpawner;
    
    private VisualElement root;
    
    private Button startMovementButton;
    private Button stopMovementButton;
    private Button newWaypointButton;
    
    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        startMovementButton = root.Q<Button>("StartFlightButton");
        stopMovementButton = root.Q<Button>("StopFlightButton");
        newWaypointButton = root.Q<Button>("NewWaypointButton");
        
        startMovementButton.clicked += StartMovementButtonOnclicked;
        stopMovementButton.clicked += StopMovementButtonOnclicked;
        newWaypointButton.clicked += NewWaypointButtonOnclicked;
    }
    

    private void StartMovementButtonOnclicked()
    {
        plane.setMovingOn();
    }
    
    
    private void StopMovementButtonOnclicked()
    {
        plane.setMovingOff();
    }
    
    
    private void NewWaypointButtonOnclicked()
    {
        waypointSpawner.generateWaypoint();
    }
}
