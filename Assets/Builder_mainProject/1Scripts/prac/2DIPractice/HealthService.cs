using System;
using UnityEngine;
using UnityEditor;

namespace Assets.Builder_mainProject._1Scripts._2DIPractice
{
    public class HealthService : IHealthService
    {
        private int _health = 100;
        public void TakeDamage(int damage)
        {
            _health -= damage;
            Debug.Log("health: " + _health);
        }
    }
}
