using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
   private State _currentState;

   [SerializeField] private State Walk;
   [SerializeField] private State Say;

   private void Update()
   {
      _currentState = Walk;
      RunCurrentState();
   }

   private void RunCurrentState()
   {
      _currentState.Run();
   }
}
