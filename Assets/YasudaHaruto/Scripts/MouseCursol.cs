//-----------------------------------------------
// MouseCursol.cs
// マウスの位置に表示するカーソルに関するスクリプト
//-----------------------------------------------
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseCursol : MonoBehaviour
{
    private Camera m_camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector2 worldPosition = m_camera.ScreenToWorldPoint(mousePosition);
        transform.position = worldPosition;
    }
}
