using UnityEngine;
using UnityEngine.UI;


public class Move : MonoBehaviour
{
    public float Speed = 4f;
    public Rigidbody rb;
    int score;
    public Text Text_score;
    //public CoinsManager Manager;
    public bool isStart = false;
    Animator anim;
    AudioSource audioSource;

    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject PanelLevelprogressUI;
    [SerializeField] GameObject PanelEndLevel;


    [SerializeField] Transform PositionPlayer;

    //Swerve
    private float lastFingerPositionX;
    private float factorMove;
    public float FactorMove => factorMove;



    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        //anim.enabled = false;
        StartPanel.SetActive(true);
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            factorMove = Input.mousePosition.x - lastFingerPositionX;
            lastFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            factorMove = 0;
        }
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //*********transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
        //Time.deltatime makatkhdmc f rigibody.velocity
        //rb.velocity = new Vector3(0,0, Speed * Time.deltaTime);
        Text_score.text = score.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            isStart = true;
            //Animation.SetActive(false);
        }
        if (isStart == true)
        {
            //transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
            transform.position += Vector3.forward * Speed * Time.deltaTime;
            //anim.enabled = true;
            anim.SetTrigger("Run");
            StartPanel.SetActive(false);
            AdManager.instance.ShowInterstitial();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //Manager.StartCoinMove(other.transform.position , ()=> 
            //{
            //    transform.localScale += new Vector3(0.4f, 0.4f, 0.4f);
            //    score++;
            //    audioSource.Play();
            //}
            transform.localScale += new Vector3(0.06f, 0.06f, 0.06f);
            score++;
            audioSource.Play();
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Obstacle"))
        {
            transform.localScale -= new Vector3(0.06f, 0.06f, 0.06f);
            //transform.localScale -= new Vector3(0.4f, 0.4f, 0.4f);
            //collision.gameObject.SetActive(false);
        }
        if (collision.collider.CompareTag("finish"))
        {
            AdManager.instance.ShowInterstitial();
            anim.SetTrigger("Dance");
            isStart = false;
            //transform.rotation to  in Y*
            PanelLevelprogressUI.SetActive(false);
            PanelEndLevel.SetActive(true);
            transform.Rotate(new Vector3(0f,-182f,0f));
            transform.position = new Vector3(PositionPlayer.position.x, PositionPlayer.position.y, PositionPlayer.position.z);
            //mli kharya tla3 FO9 toillete camera f y tweli 0.3
            CameraFollow.instace.Offset = new Vector3(-0.07f, 0.3f, -3.41f);
        }
    }

    // x : -0.08
    // y : 1.45
    // z : -2.83
}
