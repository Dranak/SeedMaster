using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Seed : MonoBehaviour
{

    public Vector3 FiringPoint { get; set; }
    public float Speed = 8f;
    public float DeathDistance = 20f;
    public float Damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        FiringPoint = transform.position;
        Debug.Log(FiringPoint.ToString());
    }

    // Update is called once per frame brambles
    void Update()
    {
        if(!Manager.Instance.IsPaused)
        {
            Move();
        }
       
    }

     virtual public void Effect(GameObject _hit)
    {
        Ennemy ennemy = _hit.GetComponent<Ennemy>();
        Debug.Log(ennemy.Life.ToString());

        ennemy.Life -= Damage;
        Debug.Log(ennemy.Life.ToString());
        float _pcLife = (float) ennemy.Life / (float)ennemy.LifeMax;
        float preChangePc = ennemy.LifeBar.fillAmount;
        ennemy.LifeBar.fillAmount = _pcLife;
        Destroy(gameObject);


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Ennemy>() != null)
        {
            Effect(collision.gameObject);
        }
        else
        {

            Debug.Log("Touché!!");
        }
    }
    

    public void Move()
    {
        if(Vector3.Distance(FiringPoint,transform.position) > DeathDistance)
        {

            Destroy(this.gameObject);
        }
        else
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
       
    }
   
}

