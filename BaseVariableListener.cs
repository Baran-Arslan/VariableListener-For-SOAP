using Obvious.Soap;
using UnityEngine;
using UnityEngine.Events;

namespace iCare.SoapVariableListener {
    public abstract class BaseVariableListener<T, TU> : MonoBehaviour where T : ScriptableVariable<TU> {
        [SerializeField] T variableToListen;
        [SerializeField] UnityEvent<TU> onValueChanged;

        void OnEnable() {
            variableToListen.OnValueChanged += OnValueChanged;
        }

        void OnDisable() {
            variableToListen.OnValueChanged -= OnValueChanged;
        }

        void OnValueChanged(TU value) {
            onValueChanged.Invoke(value);
        }
    }
}