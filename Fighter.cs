using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnVisible()
    {
        Debug.Log("OnVisible");
        GetComponent<Enemy>().StartAttacking();
    }

    void OnShoot()
    {
        GetComponent<Enemy>().ShootToDirection(0,-1);
    }
}
