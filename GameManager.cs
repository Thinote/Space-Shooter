using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject shield0;
    [SerializeField] GameObject shield1;
    [SerializeField] GameObject shield2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateShields(int num)
    {
        if(num == 0)
        {
            shield0.SetActive(false);
            shield1.SetActive(false);
            shield2.SetActive(false);
        }
        if (num == 1)
        {
            shield0.SetActive(true);
            shield1.SetActive(false);
            shield2.SetActive(false);
        }
        if (num == 2)
        {
            shield0.SetActive(true);
            shield1.SetActive(true);
            shield2.SetActive(false);
        }
        if (num == 3)
        {
            shield0.SetActive(true);
            shield1.SetActive(true);
            shield2.SetActive(true);
        }


    }
}
