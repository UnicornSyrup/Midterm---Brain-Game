using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crate : MonoBehaviour
{

    private TMP_Text label;
    public int value = 10;
    private int startValue;
    public Vector3 landingPosition = Vector3.zero;
    public float travelTime = 5f;


    private float startTime;
    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        label = GetComponentInChildren<TMP_Text>();
        startPosition = transform.position;
        startTime = Time.time;
        startValue = value;
    }

    // Update is called once per frame
    void Update()
    {
        label.text = value.ToString();

        transform.position = Vector3.Lerp(startPosition, landingPosition, (Time.time - startTime) / travelTime);

        if (Time.time - startTime >= travelTime)
        {
            // CRASH LOSE POINT
            BrainGame.Score(-50);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        Cannonball cannonball = collider.gameObject.GetComponent<Cannonball>();
        if (cannonball != null)
        {
            value -= cannonball.ammoType;

            if (value < 0)
            {
                // Destroy, lose points
                Destroy(gameObject);
                BrainGame.Score(-30);
            }
            if (value == 0)
            {
                // Destroy, gain points
                Destroy(gameObject);
                BrainGame.Score(20 + Mathf.CeilToInt(startValue / 3) * 5);
            } 

            Destroy(collider.gameObject);
        }
    }
}
