using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float offset = 10;
    // Update is called once per frame
    void LateUpdate()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(player.gameObject.transform.position.x - offset, gameObject.transform.position.y, gameObject.transform.position.z), Time.deltaTime * 100);
    }
}
