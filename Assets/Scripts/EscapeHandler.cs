using UnityEngine;

public class EscapeHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();       
    }
}
