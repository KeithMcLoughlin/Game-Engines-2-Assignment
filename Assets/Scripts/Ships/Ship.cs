using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class Ship : MonoBehaviour
    {
        public int Health = 100;
        public int Damage = 5;
        public float Speed = 20;

        public delegate void DeathDelegate();
        public event DeathDelegate OnDeath;

        public void ApplyDamage(int damage)
        {
            Debug.Log("Taken Damage: " + damage);
            Health -= damage;
            if(Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            //todo : explode
            Debug.Log("i have died");
            if (OnDeath != null)
            {
                OnDeath();
            }
            GameObject.Destroy(this.gameObject);
        }
    }
}
