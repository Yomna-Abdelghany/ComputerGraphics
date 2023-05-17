using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private void Update()
    {
        transform.position = new Vector3(player.position.x+11f-9f, player.position.y+1f- 0.5f, transform.position.z);
    }
}
