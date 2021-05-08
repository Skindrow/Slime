using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject heart;
    [SerializeField] private int hpCount;
    [SerializeField] private float drinkSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private ParticleSystem drinkParticle;


    public static float drinkSpeedStatic;


    private bool isDrinking = false;

    public bool IsDrinking
    {
        get
        {
            return isDrinking;
        }

        set
        {
            isDrinking = value;
            if (isDrinking)
            {
                drinkParticle.Play();
            }
            else
                drinkParticle.Stop();
        }
    }


    private List<GameObject> hpArr = new List<GameObject>();

    private void Start()
    {
        drinkSpeedStatic = drinkSpeed;

        drinkParticle.Stop();


        for (int i = 0; i < hpCount; i++)
        {
            GameObject hpGO = Instantiate(heart, new Vector3(-10 + i, -4.2f, 0), Quaternion.identity);
            hpArr.Add(hpGO);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "DamageObject")
        {
            PlayerDamaged();
        }
    }



    public void PlayerDamaged()
    {
        hpCount--;
        Destroy(hpArr[hpCount].gameObject);

        if (hpCount == 0)
        {
            UIController contr = GameObject.Find("Canvas").GetComponent<UIController>();
            contr.Lose();
        }



        DestroyAllDO();

    }
    private void DestroyAllDO()
    {
        GameObject[] allDamageObjects = GameObject.FindGameObjectsWithTag("DamageObject");
        foreach (GameObject damageGO in allDamageObjects)
        {
            Destroy(damageGO);
        }
    }

    public void IncreaceSize(float sizeInc)
    {
        Vector3 sizeChange = new Vector3(sizeInc, sizeInc, 0);
        transform.localScale += sizeChange;
    }
    private void Update()
    {
    }
}
