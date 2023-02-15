using System.Collections.Generic;
using UnityEngine;

// ReSharper disable All

namespace Database 
{
    
    public class Keys : MonoBehaviour 
    {
        public static KeyCode RightKey = KeyCode.D;
        public static KeyCode LeftKey = KeyCode.A;
        
        public static KeyCode UpKey = KeyCode.Space;
        public static KeyCode DownKey = KeyCode.LeftShift;
        
        public static KeyCode ForwardKey = KeyCode.W;
        public static KeyCode BackwardKey = KeyCode.S;

        public static KeyCode StartMovingKey = KeyCode.M;
        public static KeyCode StopMovingKey = KeyCode.K;
        public static KeyCode NewWaypointKey = KeyCode.N;
        
        public static string MouseAxisX = "Mouse X";
        public static string MouseAxisY = "Mouse Y";
    }
    
    
    public class Constants
    {
        public const int Height = 110; 
        public const int MapBoundaryX1 = -175;
        public const int MapBoundaryX2 = 180;
        public const int MapBoundaryZ1 = -195;
        public const int MapBoundaryZ2 = 195;
    }
    
    
    public static class Enums
    {
        public enum MovementsZ : byte
        {
            FORWARD,
            BACKWARD, 
            NONE
        }
        
        public enum MovementsX : byte
        {
            RIGHT,
            LEFT,
            NONE
        }
        
        public enum MovementsY : byte
        {
            UP, 
            DOWN,
            NONE
        }
    }
    
    
    public static class Lists
    {
        public static List<Waypoint> Waypoints = new List<Waypoint>();
    }
}