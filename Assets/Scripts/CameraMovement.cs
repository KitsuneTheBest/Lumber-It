using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Follow;
    public Vector3 OffsetFromFollowToCamera;
    public float InitialY;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        var position = transform.position;
        OffsetFromFollowToCamera = position - Follow.position;
        InitialY = position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var position = Follow.position + OffsetFromFollowToCamera;
        position.y = InitialY;
        transform.position = position;
    }
}
