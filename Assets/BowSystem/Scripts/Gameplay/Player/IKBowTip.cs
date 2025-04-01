using System;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace BowSystem.Scripts.Service
{
    public class IKBowTip : MonoBehaviour
    {
        [field: SerializeField] public SkeletonAnimation Animation { get; private set; }
        
        [field: SpineBone(dataField: "Animation")]
        [field: SerializeField] public string BoneName { get; private set; }

        private Bone bone;
        
        private void Start()
        {
            bone = Animation.Skeleton.FindBone(BoneName);
        }

        private void Update()
        {
            transform.position = bone.GetWorldPosition(transform);
        }
    }
}