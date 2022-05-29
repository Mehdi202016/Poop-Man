using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Swerve
    private float lastFingerPositionX;
    private float factorMove;
    public float FactorMove => factorMove;


    public bool isStart = false;
    public float Speed = 4f;
    [SerializeField] GameObject StartPanel;
    Animator anim;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        anim.enabled = false;
        StartPanel.SetActive(true);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFingerPositionX = Input.mousePosition.x;
            isStart = true;
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
        if (isStart == true)
        {
            transform.position += new Vector3(0, 0, Speed * Time.deltaTime);
            anim.enabled = true;
            StartPanel.SetActive(false);
        }
    }
    }
