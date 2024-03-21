using System.Collections.Generic;
using System.Linq;
using Cinemachine;
using UnityEngine;

namespace Workspace.CodeBase.Core.Camera
{
    public class CameraService : ICameraService
    {
        private readonly IEnumerable<GameCamera> _cameras;
        private readonly CinemachineBrain _brain;

        public CameraService(IEnumerable<GameCamera> cameras, 
            CinemachineBrain brain)
        {
            _cameras = cameras;
            _brain = brain;
        }


        public void Initialize(Transform player)
        {
            foreach (GameCamera camera in _cameras)
            {
                if(camera.IsPlayerCamera)
                    camera.SetTarget(player);
            }   
        }

        public Vector3 GetBrainDirection(Vector3 direction) 
            => _brain.transform.rotation * direction;

        public void ChangeCamera(int index)
        {
            if (!IsInRange(index))
                return;

            foreach (GameCamera camera in _cameras)
                camera.SetPriority(-1);
            
            _cameras.ElementAt(index).SetPriority(1);
        }

        private bool IsInRange(int index)
            => _cameras.Count() < index;
    }
}