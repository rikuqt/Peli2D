using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class liikkuminen : MonoBehaviour
{

    public float nopeus = 1.5f;

    private float korkeus = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float position_korkeus = this.transform.position.y;

        if(position_korkeus < -0.5){
            korkeus=Random.Range(0f,8f);
        }
        else if(position_korkeus > 2) {
            korkeus=Random.Range(-8f ,0f);
        }
        else {
            korkeus=Random.Range(-8f, 8f);
        }
            
        GetComponent<Transform>().Translate(
            this.nopeus*Time.deltaTime, korkeus*Time.deltaTime , 0f);

        if (GetComponent<Transform>().position.x>10f||
            GetComponent<Transform>().position.x<-10f){

                transform.Rotate(0f,180f,0f);    
            }
    }
}