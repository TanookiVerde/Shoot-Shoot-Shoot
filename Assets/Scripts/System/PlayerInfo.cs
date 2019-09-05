using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public PlayerType type;
    public Color mainColor;
    public float gravityBias;
    public string jumpButton;
    public string shootButton;
    public string moveAxis;
}
