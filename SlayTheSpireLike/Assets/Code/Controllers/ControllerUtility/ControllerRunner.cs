using System;
using System.Collections;
using System.Collections.Generic;
using Code.Utility.ControllerMethods;
using UnityEngine;
using Zenject;

namespace Code.Controllers.ControllerUtility
{
    public class ControllerRunner
    {
        private List<IControllerAction> _controllers;

        public ControllerRunner()
        {
            _controllers = new List<IControllerAction>();
        }

        public void Add(IControllerAction controllerAction)
        {
            _controllers.Add(controllerAction);
        }
        
        public void Awake()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IAwake awake)
                {
                    awake.Awake();
                }
            }
        }

        public void Start()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IStart start)
                {
                    start.Start();
                }
            }
        }

        public void Update()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IExecute execute)
                {
                    execute.Execute();
                }
            }
        }

        public void OnDestroy()
        {
            foreach (var controller in _controllers)
            {
                if (controller is IClean clean)
                {
                    clean.Clean();
                }
            }
        }
    }
}