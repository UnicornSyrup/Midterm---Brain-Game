using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private GameObject barrel;

    public float angleRange = 80f;

    // Start is called before the first frame update
    void Start()
    {
        barrel = GameObject.Find("Barrel");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 direction = mousePos3D - transform.position;

        float angle = 0f;
        angle = Mathf.Atan2(mousePos3D.y, mousePos3D.x);
        angle *= Mathf.Rad2Deg;
        angle -= 90;

        angle = Mathf.Clamp(angle, -angleRange, angleRange);

        barrel.transform.rotation = Quaternion.Euler(0, 0, angle);

        
    }
}
