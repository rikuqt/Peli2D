using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class kävely : MonoBehaviour
{
    private int suunta = 1;
    private float nopeus = 3f;
    private bool ilmassa = false;
    private float voima = 400f;
    public int pisteet = 0;
    public static int loppuPisteet;
    [SerializeField] public TextMeshProUGUI teksti;
    MusiikkiManager audioManager;

    private void Awake(){
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<MusiikkiManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pisteet " +pisteet);
        teksti.text = "Pisteet: " +pisteet;
    }

    // Update is called once per frame
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && (this.suunta!=1))
        {
            this.GetComponent<Transform>().Rotate(0f,180f,0f);
            this.suunta=1;
        }
        if (Input.GetKeyDown(KeyCode.A) && (this.suunta!=2))
        {
            this.GetComponent<Transform>().Rotate(0f,180f,0f);
            this.suunta=2;
        }
        if (Input.GetKeyDown(KeyCode.Space) && (!this.ilmassa))
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up*this.voima);
        }
        
        this.GetComponent<Transform>().Translate(
            this.nopeus*Time.deltaTime,
            0f,
            0f);

            if (GetComponent<Transform>().position.x>9f){
                transform.Rotate(0f,180f,0f);
                this.suunta=2;
            }

            if (GetComponent<Transform>().position.x<-9f){
                transform.Rotate(0f,180f,0f);
                this.suunta=1;
            }
    }

    void OnCollisionEnter2D(Collision2D a)
    {
        this.ilmassa = false;
        Debug.Log("ilmassaFalse");
        // Debug.Log(a.gameObject.name);
        if (a.gameObject.name.Equals("lintu_0 (1)"))
        {
            // Scenen Loadaus kun collide
            loppuPisteet = pisteet;
            SceneManager.LoadScene("kuolemaScene");
        }
        else if(a.gameObject.name.Equals("kolikkoja_0(Clone)"))
        {
            GameObject kolikko = GameObject.Find("kolikkoja_0(Clone)");
            Destroy(kolikko);
            pisteet++;
            Debug.Log("Pisteet: " + pisteet);
            teksti.text="Pisteet: "+pisteet;
        
        if (a.gameObject.name.Equals("kolikkoja_0(Clone)")){
            audioManager.PlaySFX(audioManager.kolikko);
        }
            // Voitto sceneen siirtyminen x kerätyn jälkeen
            if (pisteet == 5){
                Debug.Log("voitto");
                SceneManager.LoadScene("voittoScene");
            }
        }
    }

    void OnCollisionExit2D(Collision2D a)
    {
        this.ilmassa = true;
        Debug.Log("ilmassaTrue");
    }
}
