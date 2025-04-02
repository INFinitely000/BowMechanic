using BowSystem.Scripts.Service;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace BowSystem.Scripts.Gameplay.Player
{
    public class MouseIKTarget : MouseTargetable
    {
        [field: SerializeField] public SkeletonAnimation Animation { get; private set; }
        
        [field: SpineBone(dataField: "Animation")]
        [field: SerializeField] public string BoneName { get; private set; }

        public Bone Bone { get; private set; }
        
        public IInput Input { get; private set; }
        
        private void Awake()
        {
            Bone = Animation.Skeleton.FindBone(BoneName);
        }

        public override void TargetTo(Vector2 position)
        {
            position.x *= Animation.Skeleton.ScaleX;
            position.y *= Animation.Skeleton.ScaleY;
            
            Bone.SetLocalPosition(position);
        }
    }
}