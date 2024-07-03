using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    // Update is called once per frame
    void Update()
    {
        // Move the object forward along its local Z-axis
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}