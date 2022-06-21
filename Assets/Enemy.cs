using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHp;
    float moveCool = 0;
    Vector3 move = new Vector3(0,0,0);
    public Transform playerTransform;
    private Vector3 homingVec=new Vector3(0,0,0);
    private float moveSpeed = 0.005f;
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        //homingVec.x = playerTransform.position.x - transform.position.x;
        //homingVec.y = playerTransform.position.y - transform.position.y;
        //homingVec.z = playerTransform.position.z - transform.position.z;
        //homingVec.Normalize();

        //transform.position = 
        //    new Vector3(transform.position.x + homingVec.x * moveSpeed,
        //    transform.position.y + homingVec.y * moveSpeed,
        //    transform.position.z + homingVec.z * moveSpeed);

        if (enemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage()
    {
        enemyHp -= 1;
        Debug.Log(enemyHp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<PlayerMove>().Damage();
            Destroy(gameObject);
        }
    }
}
