using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed = 5;

    private Vector3 LastPosition { get; set; } = Vector3.zero;
    public Transform FiringPoint;
    public float LastTimeShot { get; set; }
    public float FiringSpeed { get; set; }
    public Seed ActualSeed { get; set; }

    public float Life { get; set; }
    public float LifeMax = 100;
    public bool IsDead { get; set; } 
    public Image LifeBar;
    public List<Seed> AllSeeds;

    // Start is called before the first frame update
    void Start()
    {
        ActualSeed = AllSeeds.FirstOrDefault();
        IsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Manager.Instance.IsPaused)
        {
            if (Life <= 0)
            {
                IsDead = true;
            }

            Mouvement();
            RotateWithMouse();
            Shoot();
        }
    }

    void Mouvement()
    {
        Animator animator = GetComponentInChildren<Animator>();
        float xVariation = Input.GetAxis("Horizontal");
        float yVariation = Input.GetAxis("Vertical");

        Vector3 newPosition = new Vector3(xVariation, 0, yVariation);

        if (LastPosition != newPosition)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        //if (LastPosition.x != newPosition.x)
        //{
        //    animator.SetBool("IsStrafing", true);
        //}
        //else
        //{
        //    animator.SetBool("IsStrafing", false);
        //}


        this.transform.Translate(newPosition * Speed * Time.deltaTime);
    }

    void RotateWithMouse()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));

        }

    }

    void Shoot()
    {
        Animator animator = GetComponentInChildren<Animator>();

        // TargetCursor.transform.Translate(Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("IsShooting", true);
            if (LastTimeShot + FiringSpeed <= Time.time)
            {
                LastTimeShot = Time.time;
                //ActualSeed.FiringPoint = this.transform.position;
                Instantiate(ActualSeed, FiringPoint.position, FiringPoint.rotation);
            }
        }
        else
        {
            animator.SetBool("IsShooting", false);
        }



    }


    public void TakeDamage(float damage)
    {
        Life -= damage;

        float _pcLife = (float)Life / (float)LifeMax;
        float preChangePc = LifeBar.fillAmount;
        LifeBar.fillAmount = _pcLife;
    }


}

