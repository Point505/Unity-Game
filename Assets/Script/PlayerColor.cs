using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EPlayerColor
{
    Red,Blue,Green,
    Pink,Lime
}


public class PlayerColor { 


    private static List<Color> colors = new List<Color>()
    {
        new Color(1f,0f,0f),
        new Color(0.1f,0.1f,1f),
        new Color(0f,0.6f,0f),
        new Color(1f,0.3f,0.9f)
      
    };

    public static Color GetColor(EPlayerColor playerColor) { return colors[(int)playerColor]; }


    public static Color Red { get { return colors[(int)EPlayerColor.Red]; } }
    public static Color Blue { get { return colors[(int)EPlayerColor.Blue]; } }
    public static Color Green { get { return colors[(int)EPlayerColor.Green]; } }
    public static Color Pink { get { return colors[(int)EPlayerColor.Pink]; } }

    public static Color Lime { get { return colors[(int)EPlayerColor.Lime]; } }
}
