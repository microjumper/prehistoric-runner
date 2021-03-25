using UnityEngine;

[CreateAssetMenu(fileName = "New Pickup", menuName = "Pickup")]
public class Pickup : ScriptableObject
{
    public new string name;
    public Sprite sprite;
    public int points;
}
