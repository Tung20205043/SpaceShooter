using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlaneController : MonoBehaviour
{
    public abstract void Move();
    public abstract void Shoot();
    public abstract void TakeDamage(float dmg);
    public abstract void Die();
}
