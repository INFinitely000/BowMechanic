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
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_isDestroyed) return;
            
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