using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lerpSpeed;

    public Transform objectToFollow;

    public float cameraPitch;
    public float cameraDistance;

    private Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, Mathf.Sin(cameraPitch), Mathf.Cos(cameraPitch)) * cameraDistance;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, objectToFollow.position - offset, Time.deltaTime * lerpSpeed);
    }
}
