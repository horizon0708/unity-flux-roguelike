using UnityEngine;
using UnityEngine.UI;

namespace MyRogueLike.components
{
    public class AgeCounter: MonoBehaviour
    {
        private GeneralManager _gm;
        private GlobalStore _gs;
        private Text _text;
        void Start()
        {
            _gm = GeneralManager.Instance;
            _gs = _gm.GlobalStore;
            
            _text = gameObject.GetComponent<Text>();
        }

        void Update()
        {
            _text.text = "Age:" + _gs.CurrentAge;
        }
    }
}