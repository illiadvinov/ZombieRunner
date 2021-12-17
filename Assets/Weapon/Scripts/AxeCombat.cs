using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeCombat : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    EnemyHealth target;
    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth target = GetComponent<EnemyHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {

            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().SetTrigger("Hit");
        }
        else
        {
            GetComponent<Animator>().enabled = false;
        }
        
         
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Hit");
        }
    }
}
