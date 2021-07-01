using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    float playerSpeed = 10f;
    bool hitDelaycheck = true;

    public GameObject bullet;
    bool shootDelaycheck = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime);

        if(Input.GetMouseButton(0) && shootDelaycheck)
        {
            StartCoroutine("shoot");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && hitDelaycheck)
        {
            StartCoroutine("Hitcheck");

        }
     }
    IEnumerator Hitcheck()
    {
        hitDelaycheck = false;
        GameManager.PlayerHit();
        yield return new WaitForSeconds(1);
        hitDelaycheck = true;

    }
    IEnumerator shoot()
    {
        shootDelaycheck = false;
        Instantiate(bullet, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(1);
        shootDelaycheck = true;

    }

    
        
    
}
