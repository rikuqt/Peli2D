using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using TMPro;

public class loppuTulos : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Lopputuloksen näyttäminen
        scoreText.text = "Loppu pisteet: " + kävely.loppuPisteet.ToString();
    }
}