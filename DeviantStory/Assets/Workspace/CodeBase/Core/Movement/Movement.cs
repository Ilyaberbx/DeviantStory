using Photon.Pun;
using UnityEngine;
using Workspace.CodeBase.Services.Input;
using Zenject;

namespace Workspace.CodeBase.Core.Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private PhotonView _photonView;
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float _speed;

        private IInputService _input;

        [Inject]
        public void Construct(IInputService input)
            => _input = input;

        private void Update()
        {
            if (_photonView.IsMine) 
                Move(_input.GetMovementInput());
        }

        private void Move(Vector2 input)
        {
            Vector3 direction = new Vector3(input.x, 0, input.y);

            direction = direction.z * transform.forward + direction.x * transform.right;

            Debug.Log("Direction: " + direction);

            _characterController.Move(direction * _speed * Time.deltaTime);
        }
    }
}