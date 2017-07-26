using UnityEngine;
using Zenject;

namespace KibbleSpace
{
    public class KibbleCreationManager : MonoBehaviour
    {
        PoolManager _poolManager;
        DeadDogSignal _deadSignal;
        RestartSignal _restartSignal;
        TextManager _displayText;

        [Inject]
        public void Begin(PoolManager poolManager, DeadDogSignal deadSignal, RestartSignal restartSignal, TextManager displayText)
        {
            _poolManager = poolManager;
            _displayText = displayText;

            _deadSignal = deadSignal;
            _deadSignal.Listen(stopCreation);

            _restartSignal = restartSignal;
            _restartSignal.Listen(startCreation);
        }

        void Start()
        {
            _displayText.displayText("Puppy is hungry! Tap on the kibbles to feed him.");
            startCreation();
        }

        public void createKibble()
        {
            _poolManager.AddKibble();
        }

        private void stopCreation()
        {
            CancelInvoke();
            _poolManager.clearPool();
        }

        private void startCreation()
        {
            InvokeRepeating("createKibble", 0f, 0.5f);
        }


        private void OnDestroy()
        {
            _deadSignal.Unlisten(stopCreation);
            _restartSignal.Unlisten(startCreation);
        }
    }
}
