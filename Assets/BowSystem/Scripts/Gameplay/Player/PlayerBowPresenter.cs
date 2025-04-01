using System;
using Spine;
using Spine.Unity;
using UnityEngine;
using Event = Spine.Event;

namespace BowSystem.Scripts.Service
{
    public class PlayerBowPresenter : MonoBehaviour
    {
        private const string AimAnimationName = "attack_start";
        private const string TargetAnimationName = "attack_target";
        private const string AttackAnimationName = "attack_finish";
        private const string ShootEventName = "shoot";
        private const string IdleAnimationName = "idle";

        [field: SerializeField] public PlayerBow Bow { get; private set; }
        [field: SerializeField] public SkeletonAnimation Animation { get; private set; }

        private bool isAim;


        private void Update()
        {
            if (isAim && Bow.isAim == false && Animation.AnimationName != AttackAnimationName) Animation.AnimationState.SetAnimation(0, IdleAnimationName, true);
            if (isAim == false && Bow.isAim)
            {
                Animation.AnimationState.ClearTrack(0);
                Animation.AnimationState.SetAnimation(0, AimAnimationName, false);
                Animation.AnimationState.AddAnimation(0, TargetAnimationName, true, 0f);
            }

            isAim = Bow.isAim;
        }

        private void OnEnable()
        {
            Animation.AnimationState.Event += OnAnimationEvent;
            Bow.TryingToShoot += OnBowTryingToShoot;
        }

        private void OnDisable()
        {
            Animation.AnimationState.Event -= OnAnimationEvent;
            Bow.TryingToShoot -= OnBowTryingToShoot;
        }

        private void OnBowTryingToShoot()
        {
            if (Animation.AnimationName == TargetAnimationName || Animation.AnimationName == AimAnimationName)
            {
                Animation.AnimationState.AddAnimation(0, AttackAnimationName, false, 0f);
                Animation.AnimationState.AddAnimation(0, IdleAnimationName, true, 0f);
            }
        }

        private void OnAnimationEvent(TrackEntry trackentry, Event e)
        {
            if (e.Data.Name == ShootEventName)
                Bow.Shoot();
        }
    }
}