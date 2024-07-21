using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDisable : IControllerAction
{
   public void Activate();
   public void Deactivate();
   public bool IsActive { get; }
}
