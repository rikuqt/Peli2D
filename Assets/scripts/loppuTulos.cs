using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class loppuTulos : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Lopputuloksen näyttäminen
        scoreText.text = "Keräsit " + kävely.loppuPisteet.ToString() + " pistettä, mutta kuolit.";
    }
}