using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ennemy : MonoBehaviour
{
    public Transform FiringPoint;
    public Spirit Spririt;
    public Seed PrefabBullet;
    public float LifeMax = 100;
    public float DamageExplose = 10;
    public Animator Animator { get; set; }
    public float Life { get;  set; }
    public float TimeStartStun { get;  set; }

    public float Speed = 2;
    public Image LifeBar;
    public bool IsStun;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
     
        Spririt = GameObject.FindGameObjectWithTag("Spirit").GetComponent<Spirit>();
        Life = LifeMax;
        Debug.Log(Spririt.transform.position.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (!Manager.Instance.IsPaused )
        {
            if(!IsStun)
            {
                MoveToSpirit();
            }
            else
            {
                if(TimeStartStun +1 >= Time.time)
                {
                    IsStun = false;
                }
            }
    

            if (Life <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    void MoveToSpirit()
    {
        
            transform.LookAt(Spririt.transform.position);
            Debug.DrawLine(Spririt.transform.position, Spririt.transform.position + Vector3.up*Mathf.Infinity, Color.red);
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        

    }

    private void Explose()
    {
      //  Spririt.Life -= DamageExplose;
        Spririt.TakeDamage(DamageExplose);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Spirit>() != null )
        {
            Explose();
            Destroy(gameObject);
            Debug.Log(" Pas Boum!!");
        }
        else if (collision.gameObject.GetComponent<Player>() == null)
        {
            Animator.SetBool("NeedJump", true);
            Debug.Log(" Pas Boum!!");
        }
       
    }
}
