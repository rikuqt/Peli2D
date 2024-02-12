using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class kolikkotehdas : MonoBehaviour
{

    public GameObject kolikko = null;

    private float ajastinlaskuri = 0f;
    private GameObject apukolikko;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // aika kolikoiden luonnin välillä
        ajastinlaskuri += Time.deltaTime;
        // luodaan uusi kolikko kun aikaa on kulunut riittävästi
        if (ajastinlaskuri >= 6f){

            if (apukolikko != null){
                Destroy(apukolikko);
            }

            // luodaan uusi kolikko satunnaiseen paikkaan
            apukolikko = Instantiate(kolikko, new Vector3(
                Random.Range(-8f, 8f),
                Random.Range(0f, 3f),
                0f), 
                Quaternion.identity);
            ajastinlaskuri=0;
            
        }
    }
}
