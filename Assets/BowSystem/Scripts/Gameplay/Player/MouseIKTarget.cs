using System;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public class MouseIKTarget : MonoBehaviour
    {
        [field: SerializeField] public SkeletonAnimation Animation { get; private set; }
        
        [field: SpineBone(dataField: "Animation")]
        [field: SerializeField] public string BoneName { get; private set; }

        public Bone Bone { get; private set; }
        
        public IInput Input { get; private set; }
        
        public void Construct(IInput input)
        {
            Input = input;

            Bone = Animation.Skeleton.FindBone(BoneName);
        }


        private void Update()
        {
            var mousePosition = Input.AimPosition;
            var worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            var skeletonSpacePoint = Animation.transform.InverseTransformPoint(worldMousePosition);
            skeletonSpacePoint.x *= Animation.Skeleton.ScaleX;
            skeletonSpacePoint.y *= Animation.Skeleton.ScaleY;
            
            Bone.SetLocalPosition(skeletonSpacePoint);
        }
    }
}