using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Crate : MonoBehaviour
{
    private TMP_Text label;
    // Start is called before the first frame update
    void Start()
    {
        label = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        label.text = "10";
    }
}
