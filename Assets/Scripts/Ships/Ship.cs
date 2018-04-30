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
        public List<Boid> Targets;
        public float AttackRange;
        public GameObject BulletPrefab;
        public GameObject BulletSpawnPosition;
        public float FireRate = 2.0f;
        float elapsed = 0.0f;
        Boid currentTarget;
        ChaseTarget chaseBehaviour;

        public delegate void DeathDelegate();
        public event DeathDelegate OnDeath;

        public GameObject ExplosionPrefab;

        void Start()
        {
            currentTarget = Targets[UnityEngine.Random.Range(0, Targets.Count)];
            chaseBehaviour = GetComponent<ChaseTarget>();
            chaseBehaviour.target = currentTarget;
        }
        
        void Update()
        {
            if(Vector3.Distance(currentTarget.transform.position, transform.position) < AttackRange && elapsed > FireRate)
            {
                GameObject bullet = GameObject.Instantiate<GameObject>(BulletPrefab);
                bullet.transform.position = BulletSpawnPosition.transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.transform.parent = this.transform;
                bullet.gameObject.GetComponent<Bullet>().Damage = this.Damage;
                elapsed = 0.0f;
            }

            elapsed += Time.deltaTime;
        }
        
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
