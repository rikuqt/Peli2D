using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class kävely : MonoBehaviour
{
    private int suunta = 1;
    private float nopeus = 3f;
    private bool ilmassa = false;
    private float voima = 400f;
    private int pisteet = 0;
    [SerializeField] private TextMeshProUGUI teksti;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Pisteet " +pisteet);
        teksti.text = "Pisteet: " +pisteet;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && (this.suunta != 1))
        {
            GetComponent<Transform>().Rotate(0f, 180f, 0f);
            suunta = 1;
        }

        if (Input.GetKeyDown(KeyCode.A) && (this.suunta != 2))
        {
            GetComponent<Transform>().Rotate(0f, 180f, 0f);
            suunta = 2;
        }

        GetComponent<Transform>().Translate(this.nopeus * Time.deltaTime, 0f, 0f);
        if (this.GetComponent<Transform>().position.x > 11f) 
        {
            this.transform.Rotate(0f,180f,0f);
            this.suunta = 2;
        }
        if (this.GetComponent<Transform>().position.x < -11f)
        {
            this.transform.Rotate(0f,180f,0f);
            this.suunta = 1;
        }

        if (Input.GetKeyDown(KeyCode.Space) && (!this.ilmassa))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * this.voima);
        }
    }

    void OnCollisionEnter2D(Collision2D a)
    {
        this.ilmassa = false;
        Debug.Log(a.gameObject.name);
        if (a.gameObject.name.Equals("lintu_0 (1)"))
        {
            // Load a scene named "YourSceneName" when colliding with "lintu_0 (1)"
            SceneManager.LoadScene("kuolemaScene");
        }
        else if(a.gameObject.name.Equals("kolikkoja_0(Clone)"))
        {
            GameObject kolikko = GameObject.Find("kolikkoja_0(Clone)");
            Destroy(kolikko);
            pisteet++;
            Debug.Log("Pisteet: " + pisteet);
            teksti.text="Pisteet: "+pisteet;
            this.ilmassa = false;
            if (pisteet == 2){
                Debug.Log("jeejee");
                SceneManager.LoadScene("voittoScene");
            }
        }
    }

    void OnCollisionExit2D(Collision2D a)
    {
        this.ilmassa = true;
    }
}
