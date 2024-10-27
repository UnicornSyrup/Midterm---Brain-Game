using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShootUI : MonoBehaviour
{
    public KeyCode keyMap = KeyCode.S;
    public int ammoType = 1;
    private int ammoRemaining = 50;

    private TMP_Text typeLabel;
    private TMP_Text keyLabel;
    private TMP_Text ammoLabel;

    private void Awake()
    {
        typeLabel = transform.Find("TypeLabel").GetComponent<TMP_Text>();
        keyLabel = transform.Find("KeyLabel").GetComponent <TMP_Text>();
        ammoLabel = transform.Find("AmmoLabel").GetComponent< TMP_Text>();

        typeLabel.text = ammoType.ToString();
        keyLabel.text = keyMap.ToString();
        ammoLabel.text = ammoRemaining.ToString();
    }

    public void SetAmmo(int ammo)
    {
        ammoRemaining = ammo;
        ammoLabel.text = ammoRemaining.ToString();
    }

    public bool Fire()
    {
        if (ammoRemaining <= 0) return false;

        SetAmmo(ammoRemaining - 1);
        return true;
    }
}
