using UnityEngine;

// ReSharper disable All

namespace Database {
    
    public class Keys : MonoBehaviour {
        public static KeyCode startKey = KeyCode.UpArrow;
        public static KeyCode stopKey = KeyCode.DownArrow;
        
        public static KeyCode rightKey = KeyCode.D;
        public static KeyCode leftKey = KeyCode.A;
        
        public static KeyCode upkey = KeyCode.Space;
        public static KeyCode downKey = KeyCode.LeftShift;
        
        public static KeyCode forwardKey = KeyCode.W;
        public static KeyCode backwardKey = KeyCode.S;

        public static string mouseAxisX = "Mouse X";
        public static string mouseAxisY = "Mouse Y";
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
}