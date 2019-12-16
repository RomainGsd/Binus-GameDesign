using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target != null ?
            new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z) :
            new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
