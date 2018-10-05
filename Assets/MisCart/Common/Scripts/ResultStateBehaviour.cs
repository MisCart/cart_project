//----------------------------------------------
//            Behaviour Machine
// Copyright Â© 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    public abstract class ResultStateBehaviour : InternalStateBehaviour {
        public abstract void OnClick();
        public abstract void OnBack();
    }
}