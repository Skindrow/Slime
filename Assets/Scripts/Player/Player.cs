using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
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


    private void Start()
    {
        drinkSpeedStatic = drinkSpeed;

        drinkParticle.Stop();

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

        UIController contr = GameObject.FindObjectOfType<UIController>();
        contr.Lose();
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
