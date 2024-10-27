using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cannonball : MonoBehaviour
{
    public Vector3 direction;
    public int ammoType;

    private void Start()
    {
        gameObject.GetComponentInChildren<TMP_Text>().text = ammoType.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * Time.deltaTime;
        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.y) > 20)
        {
            Destroy(gameObject);
        }
    }
}
