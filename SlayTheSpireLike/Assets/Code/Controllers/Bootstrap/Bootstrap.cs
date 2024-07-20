using System;
using System.Collections;
using Code.Controllers.ControllerUtility;
using Code.Controllers.InicializationSystem;
using UnityEngine;

namespace Code.Controllers.Bootstrap
{
    public class Bootstrap : MonoBehaviour
    {
        private ControllerRunner _controllerRunner;
        private IInicializationController _inicializationController;
        public void Awake()
        {
            _controllerRunner = new ControllerRunner();
            _inicializationController = new GameInicializationController(_controllerRunner);
            _inicializationController.Init();
            _controllerRunner.Awake();
        }
        public void Start()
        {
            _controllerRunner.Start();
        }

        public void OnDestroy()
        {
            _controllerRunner.OnDestroy();
        }
    }
}