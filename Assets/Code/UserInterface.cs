using UnityEngine;
using UnityEngine.UIElements;

// ReSharper disable All

public class UserInterface : MonoBehaviour
{
    [SerializeField] private PlaneMove plane;

    private VisualElement root;
    private Button startMovementButton;
    private Button stopMovementButton;
    
    
    public void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;

        startMovementButton = root.Q<Button>("StartFlightButton");
        stopMovementButton = root.Q<Button>("StopFlightButton");

        startMovementButton.clicked += StartMovementButtonOnclicked;
        stopMovementButton.clicked += StopMovementButtonOnclicked;
    }

    
    private void StartMovementButtonOnclicked()
    {
        plane.setMovingOn();
    }
    
    
    private void StopMovementButtonOnclicked()
    {
        plane.setMovingOff();
    }
}
