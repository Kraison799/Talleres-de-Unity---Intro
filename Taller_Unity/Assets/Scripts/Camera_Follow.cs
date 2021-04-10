using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    // Variables
    public GameObject target;
    public Camera cam;
    public float posX;
    public float posY;
    public float posZ;
    private Vector3 camDistance;

    // Start is called before the first frame update
    void Start()
    {
        camDistance = new Vector3(posX, posY, posZ);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + camDistance;
        cam.transform.LookAt(target.transform.position);
    }
}
