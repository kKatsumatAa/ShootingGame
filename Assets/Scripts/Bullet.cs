using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float time = 15;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z += 0.5f;
        transform.position = new Vector3(pos.x, pos.y, pos.z);

        //���Ԑ����������玩�R����
        time -= Time.deltaTime;
        if (time <= 0||transform.position.z>=14)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Damage();
        }
        Destroy(this.gameObject);
    }
}