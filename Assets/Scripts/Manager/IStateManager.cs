using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class StateManager: MonoBehaviour
{
   public abstract void InitState();
   public abstract void EnterState();
   public abstract void ExitState();
}
