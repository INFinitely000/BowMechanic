using System;
using UnityEngine;

namespace BowSystem.Scripts.Gameplay.Player
{
    public class TrajectoryRenderer : MonoBehaviour
    {
        [field: SerializeField] public PlayerBowPresenter BowPresenter { get; private set; }
        [field: SerializeField] public GameObject Content { get; private set; }
        [field: SerializeField] public Transform[] Points { get; private set; }
        
        [field: SerializeField, Min(0)] public float TrajectorySimulateTime { get; private set; }
      

        private void Update()
        {
            var isEnable = BowPresenter.State == PlayerBowPresenterState.Targeting;
            
            Content.SetActive(isEnable);
            
            if (isEnable)
            {
                for (int index = 0; index < Points.Length; index++)
                {
                    float time = index * (TrajectorySimulateTime / Points.Length);
                    var position = (Vector2)BowPresenter.Bow.Tip.position + BowPresenter.Bow.Velocity * time +
                                   Physics2D.gravity * time * time / 2f;
                    Points[index].transform.position = position;
                }
            }
        }
    }
}