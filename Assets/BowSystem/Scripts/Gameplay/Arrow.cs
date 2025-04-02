using System;
using System.Collections;
using Spine.Unity;
using UnityEngine;

namespace BowSystem.Scripts.Gameplay
{
    public class Arrow : MonoBehaviour
    {
        [field: SerializeField] public SkeletonAnimation Animation { get; private set; }
        [field: SerializeField] public Rigidbody2D Rigidbody { get; private set; }

        private bool _isDestroyed;

        public float Radius { get; private set; }
        public float Power { get; private set; }
        
        public void Construct(float radius, float power)
        {
            Radius = radius;
            Power = power;
        }
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_isDestroyed) return;

            var hits = Physics2D.CircleCastAll(transform.position, Radius, transform.forward, Radius);

            foreach (var hit in hits)
            {
                if (hit.rigidbody != null)
                {
                    var difference = (Vector2)transform.position - hit.point;
                    var velocity = difference.normalized * Mathf.Max(0, Radius - difference.magnitude) * difference.normalized;
                    
                    hit.rigidbody.AddForceAtPosition(velocity, transform.position, ForceMode2D.Impulse);
                }
            }
            
            StartCoroutine(Destroy());
        }


        private void Update()
        {
            if (_isDestroyed == false) Rigidbody.MoveRotation(Quaternion.Euler(Vector3.forward * -Vector2.SignedAngle(Rigidbody.velocity, Vector2.right)));
        }


        private IEnumerator Destroy()
        {
            _isDestroyed = true;
            
            Rigidbody.bodyType = RigidbodyType2D.Static;
            GetComponent<Collider2D>().enabled = false;

            Animation.AnimationState.SetAnimation(0, "attack", false);

            yield return new WaitUntil(() => Animation.AnimationState.GetCurrent(0).IsComplete);

            Destroy(gameObject);
        }
    }
}