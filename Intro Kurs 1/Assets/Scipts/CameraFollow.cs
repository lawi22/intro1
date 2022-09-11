using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    GameObject followTarget;
    private Vector3 offset = new Vector3(0f, 2f, -10);

    public float smoothSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        followTarget = GameObject.Find("Player");
        print(followTarget.name);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 desiredPosition = followTarget.transform.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(gameObject.transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        //Lerp = Spelarens nuvarande v�rde, o det v�rdet vi vill ha o r�knar ut �ver tid (mindre hackigt)
        gameObject.transform.position = smoothPosition;
    }
}
