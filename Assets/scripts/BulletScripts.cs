using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScripts : MonoBehaviour
{
    float bulletSpeed = 10.0f;
    Vector3 firstPos;
    Vector3 curPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, bulletSpeed * Time.deltaTime);
        curPos = transform.position;
        if (Vector3.Distance(firstPos, curPos) > 10f)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
