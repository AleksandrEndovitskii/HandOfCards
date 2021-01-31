using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace Managers
{
    public class UserInterfaceManager : MonoBehaviour, IInitilizable, IUnInitializeble
    {
        [SerializeField]
        private Canvas _userInterfaceCanvasPrefab;
        [SerializeField]
        private EventSystem _eventSystemPrefab;
        [SerializeField]
        private Camera _mainCameraPrefab;

        [NonSerialized]
        public Canvas UserInterfaceCanvasInstance;
        [NonSerialized]
        public EventSystem EventSystemInstance;
        [NonSerialized]
        public Camera MainCameraInstance;

        public void Initialize()
        {
            UserInterfaceCanvasInstance = Instantiate(_userInterfaceCanvasPrefab);
            EventSystemInstance = Instantiate(_eventSystemPrefab);
            MainCameraInstance = Instantiate(_mainCameraPrefab);
        }
        public void UnInitialize()
        {

        }
    }
}
