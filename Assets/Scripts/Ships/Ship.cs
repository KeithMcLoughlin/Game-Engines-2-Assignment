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
        public bool dead = false;

        public delegate void DeathDelegate();
        public event DeathDelegate OnDeath;

        public GameObject ExplosionPrefab;

        public void ApplyDamage(int damage)
        {
            Health -= damage;
            if(Health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            GameObject explosion = GameObject.Instantiate<GameObject>(ExplosionPrefab);
            explosion.transform.position = this.transform.position;
            var particleSystem = explosion.GetComponent<ParticleSystem>();
            particleSystem.Play();

            if (OnDeath != null)
            {
                OnDeath();
            }
            dead = true;
            GameObject.Destroy(this.gameObject);
        }
    }
}
