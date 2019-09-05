using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/MapInfo")]
public class MapInfo : ScriptableObject
{
    public string title;
    public float timeLimit;
    public Vector3[] initialPositions = new Vector3[2];
}
