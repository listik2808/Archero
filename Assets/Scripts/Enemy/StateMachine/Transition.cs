using UnityEngine;

namespace Scripts.Enemy.StateMachine
{
    public class Transition : MonoBehaviour
    {
        public bool NeedTransition { get; private set; }

        public void SetNextState()
        {
            NeedTransition = true;
        }

        public void DiactivateTransition()
        {
            NeedTransition = false;
        }

    }
}
