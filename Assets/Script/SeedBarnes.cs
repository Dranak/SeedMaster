using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBarnes : Seed
{
    // Start is called before the first frame update
    //    void Start()
    //    {
    //        base.Start()
    //    }

    //    // Update is called once per frame
    //    void Update()
    //    {

    //    }

    public override void Effect(GameObject _hit)
    {

        Ennemy ennemy = _hit.GetComponent<Ennemy>();
        ennemy.IsStun = true;
        ennemy.TimeStartStun = Time.time;
        base.Effect(_hit);
    }

}
