using System;
using Spine;
using Spine.Unity;
using UnityEngine;
using Event = Spine.Event;

namespace BowSystem.Scripts.Gameplay.Player
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

        public PlayerBowPresenterState State
        {
            get
            {
                switch(Animation.AnimationName)
                {
                    case AimAnimationName: return PlayerBowPresenterState.Aiming;  
                    case TargetAnimationName: return PlayerBowPresenterState.Targeting; 
                    case AttackAnimationName: return PlayerBowPresenterState.Shoot; 
                    
                    default: return PlayerBowPresenterState.Idle;
                }
            }
        }


        
        public void StartAiming()
        {
            Animation.AnimationState.ClearTrack(0);
            Animation.AnimationState.SetAnimation(0, AimAnimationName, false);
            Animation.AnimationState.AddAnimation(0, TargetAnimationName, true, 0f);
        }

        public void EndAiming()
        {
            if (State != PlayerBowPresenterState.Shoot) 
                Idle();
        }
        
        private void Idle()
        {
            Animation.AnimationState.SetAnimation(0, IdleAnimationName, true);
        }
        

        private void OnBowTryingToShoot()
        {
            if (State == PlayerBowPresenterState.Targeting)
                Animation.AnimationState.SetAnimation(0, AttackAnimationName, false);
        }
        
        private void Start() => Idle();
        
        private void OnEnable()
        {
            Animation.AnimationState.Event += OnAnimationEvent;
            
            Bow.TryingToShoot += OnBowTryingToShoot;
            Bow.StartedAiming += StartAiming;
            Bow.EndedAiming += EndAiming;
        }

        private void OnDisable()
        {
            Animation.AnimationState.Event -= OnAnimationEvent;
            
            Bow.TryingToShoot -= OnBowTryingToShoot;
            Bow.StartedAiming -= StartAiming;
            Bow.EndedAiming -= EndAiming;
        }

        private void OnAnimationEvent(TrackEntry trackentry, Event e)
        {
            if (e.Data.Name == ShootEventName)
                Bow.Shoot();
        }

    }
}