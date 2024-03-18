using System.Threading;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace Workspace.CodeBase.UI.LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {

        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Ease _ease;
        private CancellationTokenSource _cts;

        private void Awake()
        {
            _cts = new CancellationTokenSource();
            _canvasGroup.alpha = 0f;
        }

        public async UniTask Show() =>
            await _canvasGroup.DOFade(1, 0.8f)
                .SetEase(_ease).WithCancellation(_cts.Token);

        public void ShowImmediately() 
            => _canvasGroup.alpha = 1;

        public async UniTask Hide()
        {
            await _canvasGroup.DOFade(0, 0.8f)
                .SetEase(_ease)
                .WithCancellation(_cts.Token);
        }

        public void Cancel()
            => _cts.Cancel();
    }
}