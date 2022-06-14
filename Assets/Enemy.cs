using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int enemyHp;
    float moveCool = 0;
    Vector3 move = new Vector3(0,0,0);
    // Start is called before the first frame update
    void Start()
    {
        enemyHp = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        moveCool += Time.deltaTime;
        if (moveCool >= 0.2f)
        {
            moveCool = 0;
            move.x = Random.Range(-0.005f, 0.005f);
            move.y = Random.Range(-0.005f, 0.005f);
        }
        transform.position=new Vector3(transform.position.x+move.x,
             transform.position.y+move.y, transform.position.z);
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
}
