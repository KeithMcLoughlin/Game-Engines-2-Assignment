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
        AvoidCloseObstacles obstacleAvoidenceBehaviour;

        public delegate void DeathDelegate();
        public event DeathDelegate OnDeath;

        public GameObject ExplosionPrefab;

        void Start()
        {
            chaseBehaviour = GetComponent<ChaseTarget>();
            obstacleAvoidenceBehaviour = GetComponent<AvoidCloseObstacles>();
            SetRandomTarget();
        }
        
        void Update()
        {
            if (currentTarget != null && Vector3.Distance(currentTarget.transform.position, transform.position) < AttackRange && elapsed > FireRate)
            {
                Vector3 distVec = currentTarget.transform.position - transform.position;
                distVec.Normalize();
                float dot = Vector3.Dot(distVec, transform.forward);

                float angle = Mathf.Acos(dot);
                float fov = 45.0f * Mathf.Deg2Rad;
                float halfFov = fov / 2.0f;
                if (angle < halfFov)
                {
                    GameObject bullet = GameObject.Instantiate<GameObject>(BulletPrefab);
                    bullet.transform.position = BulletSpawnPosition.transform.position;
                    bullet.transform.rotation = transform.rotation;
                    bullet.gameObject.GetComponent<Bullet>().Damage = this.Damage;
                    elapsed = 0.0f;
                }
            }

            if (currentTarget == null || obstacleAvoidenceBehaviour.ObjectsInVicinity.Contains(currentTarget.gameObject))
                SetToAnotherTarget();

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
        
        public void SetRandomTarget()
        {
            currentTarget = Targets[UnityEngine.Random.Range(0, Targets.Count)];
            chaseBehaviour.target = currentTarget;
        }
        
        public void SetToAnotherTarget()
        {
            Boid newTarget = null;
            foreach(var target in Targets)
            {
                if (target != null && !obstacleAvoidenceBehaviour.ObjectsInVicinity.Contains(target.gameObject))
                {
                    newTarget = target;
                    break;
                }
            }
            chaseBehaviour.target = newTarget;
        }
    }
}
