using Scripts.Hero;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Scripts.Logic
{
    public class StartCountdown : MonoBehaviour
    {
        [SerializeField] private float _elapsedTime;
        [SerializeField] private TMP_Text _textTwo;
        [SerializeField] private TMP_Text _textThree;
        [SerializeField] private TMP_Text _textStart;

        private float _timeDown = 0;
        private HeroMove _heroMove;
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void SetComponent(GameObject hero)
        {
            _heroMove = hero.GetComponent<HeroMove>();
        }

        public void Show() => StartCoroutine(CountingDown());

        public void Hide()
        {
            _heroMove.enabled = true;
            _timeDown = 0;
            gameObject.SetActive(false);
        }

        private IEnumerator CountingDown()
        {
            _heroMove.enabled = false;

            while (_timeDown <= _elapsedTime)
            {
                _timeDown += Time.deltaTime;

                if (_timeDown >= 1 && _textThree.gameObject.activeInHierarchy == false)
                {
                    _textThree.gameObject.SetActive(true);
                }
                if (_timeDown >= 2 && _textTwo.gameObject.activeInHierarchy == false)
                {
                    _textThree.alpha = 0;
                    _textTwo.gameObject.SetActive(true);
                }
                if (_timeDown >= 3 && _textStart.gameObject.activeInHierarchy == false)
                {
                    _textTwo.alpha = 0;
                    _textStart.gameObject.SetActive(true);
                }
                yield return null;
            }
            Hide();
        }
    }
}