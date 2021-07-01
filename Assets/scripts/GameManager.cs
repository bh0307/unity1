using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Image HPbar;
    public static float HP = 1.0f;
    public GameObject enemyObject;
    bool isInstant = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInstant)
        {
            StartCoroutine("InstantEnemy");

        }
        HPbar.fillAmount = HP;
    }

    public static void PlayerHit()
    {
        HP -= 0.1f;
    }
    IEnumerator InstantEnemy()
    {
        isInstant = false;
        Instantiate(enemyObject, new Vector3(Random.Range(-50, 50), 1, Random.Range(-50, 50)), Quaternion.identity);
        yield return new WaitForSeconds(2);
        isInstant = true;

    }
}
