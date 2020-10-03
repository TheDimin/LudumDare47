using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tools.StateManager
{
    internal class ExampleStateManagerImplementation : MonoBehaviour
    {
        StateManagerBase<StateBase> StateManager = new StateManagerBase<StateBase>();

        class ExampleState : StateBase
        {
            private string StateName;
            public ExampleState(string name)
            {
                StateName = name;
            }

            public override void OnEnterState()
            {
                Debug.Log($"Enter state:{StateName}");
            }

            public override void OnExitState()
            {
                Debug.Log($"Enter state:{StateName}");
            }

            public override bool CanEnter(StateBase currentStateBase)
            {
                Debug.Log($"Can we enter state '{StateName}' ? ");
                return true;
            }

            public override bool CanExit()
            {
                Debug.Log($"Can we Exit state '{StateName}' ? ");
                return false;
            }
        }

        private void Awake()
        {
            StateManager.RegisterState(new ExampleState("state1"));
            StateManager.RegisterState(new ExampleState("state2"));
            StateManager.RegisterState(new ExampleState("state3"));
        }

        private void Update()
        {
            //This has to be called in the update otherwise the states can't update or change the current state
            StateManager.Update();
        }
    }

    public class StateManagerBase<GameStateType> where GameStateType : StateBase
    {
        [System.Serializable]
        public class StateChangeEvent : UnityEvent<GameStateType> { };
        protected StateChangeEvent onStateChange = new StateChangeEvent();

        protected List<GameStateType> registerdStates = new List<GameStateType>();
        protected GameStateType currentState;


        /// <summary>
        /// Update State loop and current state
        /// </summary>
        public virtual void Update()
        {
            if (currentState != null)
            {
                if (currentState.CanExit())
                {
                    for (int i = 0; i < registerdStates.Count; i++)
                    {
                        if (registerdStates[i] != currentState)
                        {
                            if (registerdStates[i].CanEnter(currentState))
                            {
                                SetCurrentState(registerdStates[i]);
                                break;
                            }
                        }
                    }
                }

                currentState.Update();
            }
            else
            {
                Debug.LogWarning(this.ToString() + " has no current state");
            }
        }

        public virtual void FixedUpdate()
		{
            if (currentState != null)
			{
                currentState.FixedUpdate();
			}
		}

        /// <summary>
        /// Adds a new state to the statemanager
        /// </summary>
        /// <param name="stateBase"></param>
        public virtual void RegisterState(GameStateType stateBase)
        {
            if (!registerdStates.Contains(stateBase))
            {
                registerdStates.Add(stateBase);
            }

            if (currentState == null)
            {
                if (stateBase.CanEnter(null))
                    SetCurrentState(stateBase);
            }
        }


        /// <summary>
        /// Force the state to enter specific state
        /// </summary>
        /// <param name="newActivestate"></param>
        protected virtual void SetCurrentState(GameStateType newActivestate)
        {
            if (newActivestate == null) return;

            if (currentState != null)
                currentState.OnExitState();

            currentState = newActivestate;
            newActivestate.OnEnterState();

            onStateChange.Invoke(currentState);

            Debug.Log($"[{this.ToString()}]: Changed state to '{currentState.ToString()}'");
        }

        /// <summary>
        /// Returns the currently Active state
        /// </summary>
        /// <returns></returns>
        public GameStateType GetState()
        {
            return currentState;
        }

        /// <summary>
        /// Function will be called when a new state is enterdt
        /// </summary>
        /// <param name="action"></param>
        public void BindOnStateChange(UnityAction<GameStateType> action)
        {
            onStateChange.AddListener(action);
        }

        public void RemoveOnStateChangeBind(UnityAction<GameStateType> action)
        {
            onStateChange.RemoveListener(action);
        }

        /// <summary>
        /// Returns the first State of type
        /// </summary>
        /// <typeparam name="State"></typeparam>
        /// <param name="AllowSubClass">When there is no state of type found are we allowed to return subclasses of type</param>
        /// <returns></returns>
        public State FindState<State>(bool AllowSubClass = false) where State : GameStateType
        {
            foreach (GameStateType registerdState in registerdStates)
            {
                if (registerdState.GetType() == typeof(State))
                {
                    return registerdState as State;
                }
            }

            if (AllowSubClass)
            {
                foreach (GameStateType registerdState in registerdStates)
                {
                    if (registerdState.GetType().IsSubclassOf(typeof(State)))
                    {
                        return registerdState as State;
                    }
                }
            }
            return null;
        }
    }
}