using Photon.Pun;
using UnityEngine;

namespace Workspace.CodeBase.Core.Test
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private PhotonView _photonView;
        
        private void Update()
        {
            if (!_photonView.IsMine)
                return;
            
            if(Input.GetKey(KeyCode.A)) transform.Translate(-Time.deltaTime * 5, 0 ,0);
            if(Input.GetKey(KeyCode.D)) transform.Translate(Time.deltaTime * 5, 0 ,0);
        }
    }
}