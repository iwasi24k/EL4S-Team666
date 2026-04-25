using UnityEngine;

public class CameraControl : MonoBehaviour {
    [SerializeField] private float _CameraSpeed = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var pos = transform.position;
        transform.position = new Vector3(transform.position.x + _CameraSpeed, transform.position.y, transform.position.z);
    }
}
