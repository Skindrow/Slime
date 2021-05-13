using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bursts : MonoBehaviour
{
    [SerializeField] protected GameObject shot;
    [SerializeField] protected float force;
    [SerializeField] protected Transform target;
    [SerializeField] protected float timeToReact;
    [SerializeField] protected int numsOfShots;
    [SerializeField] public float timeBeforeDestroy = 2;
    [SerializeField] public GameObject[] shoots;


}
