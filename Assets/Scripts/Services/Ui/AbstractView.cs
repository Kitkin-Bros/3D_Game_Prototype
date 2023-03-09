using UnityEngine;

namespace Services.Ui {
    public abstract class AbstractView : MonoBehaviour {

        [SerializeField]
        private GameObject _content;
        public void Show() {
            _content.SetActive(true);
        }
        
        public void Hide() {
            _content.SetActive(false);
        }
    }
}