using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_CameraLevel2 : MonoBehaviour
{
    public List<GameObject> players;
    private Camera _camera;
    public float dampTime = 0.15f;
    public float smoothTime = 2f;
    public float zoomvalue;
    private Vector3 velocity = Vector3.zero;


    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (players[GameManagerLevel2.actualPlayer] != null)
        {
            Vector3 point = _camera.WorldToViewportPoint(players[GameManagerLevel2.actualPlayer].transform.position);
            Vector3 delta = players[GameManagerLevel2.actualPlayer].transform.position - _camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
    }
}
