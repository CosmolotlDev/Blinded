using UnityEngine;

public class SimpleNoteBehavior : MonoBehaviour
{
    public string noteText;
    public bool DebugOnStart = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(DebugOnStart)
        {
            Debug.Log($"GameObject {name} has associated note to display: {noteText}");
        }
    }

}
