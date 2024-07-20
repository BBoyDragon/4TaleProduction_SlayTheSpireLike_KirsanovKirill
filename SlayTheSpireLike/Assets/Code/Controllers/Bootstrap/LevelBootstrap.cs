using System;
using System.Collections;
using Code.Controllers.ControllerUtility;
using Code.Controllers.InicializationSystem;
using UnityEngine;

namespace Code.Controllers.Bootstrap
{
    public class LevelBootstrap: MonoBehaviour
    {
        private ControllerRunner _controllerRunner;
        private IInicializationController _inicializationController;

        public void Awake()
        {
            _controllerRunner = new ControllerRunner();
            _inicializationController = new LevelInicializationController(_controllerRunner);
            _inicializationController.Init();
            _controllerRunner.Awake();
        }

        public void Start()
        {
            _controllerRunner.Start();
        }

        public void Update()
        {
            _controllerRunner?.Update();
        }

        public void OnDestroy()
        {
            _controllerRunner.OnDestroy();
        }
    }
}