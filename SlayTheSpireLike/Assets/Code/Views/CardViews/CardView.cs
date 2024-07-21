using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

namespace Code.Views
{
    public class CardView: MonoBehaviour
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _Description;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private SortingGroup _sortingGroup;
        [SerializeField] private GameObject _fire;
        [SerializeField] private TMP_Text _energy;
        
        private Vector3 originalScale;
        private Vector3 originalPosition;
        private Vector3 hoverScale = new Vector3(0.3f, 0.75f, 1f);
        private Vector3 hoverPosition;
        private float duration = 0.5f;
        private int originalSortingOrder;
        private int hoverSortingOrder;
        private Coroutine scaleCoroutine;

        public event Action OnCardWasClicked; 

        public TMP_Text Name => _name;

        public TMP_Text Description => _Description;

        public SpriteRenderer SpriteRenderer1 => _spriteRenderer;

        public TMP_Text Energy => _energy;


        void Start()
        {
            originalScale = transform.localScale;
            originalPosition = transform.localPosition;
            hoverPosition = originalPosition + Vector3.up;
            originalSortingOrder = _sortingGroup.sortingOrder;
            hoverSortingOrder = originalSortingOrder + 2;
            SetNormalView();
        }

        private void OnMouseDown()
        {
            OnCardWasClicked?.Invoke();
        }

        void OnMouseEnter()
        {
            if (scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
            }
            scaleCoroutine = StartCoroutine(ScaleOverTime(transform, hoverScale,hoverPosition,hoverSortingOrder, duration));
        }

        void OnMouseExit()
        {
            if (scaleCoroutine != null)
            {
                StopCoroutine(scaleCoroutine);
            }
            scaleCoroutine = StartCoroutine(ScaleOverTime(transform, originalScale, originalPosition,originalSortingOrder,duration));
        }

        private IEnumerator ScaleOverTime(Transform target, Vector3 toScale,Vector3 toPosition, int toOrder, float duration)
        {
            Vector3 startScale = target.localScale;
            Vector3 startPosition = target.localPosition;
            _sortingGroup.sortingOrder = toOrder;
            float elapsed = 0f;

            while (elapsed < duration)
            {
                target.localScale = Vector3.Lerp(startScale, toScale, elapsed / duration);
                target.localPosition = Vector3.Lerp(startPosition, toPosition, elapsed / duration);
                elapsed += Time.deltaTime;
                yield return null;
            }

            target.localScale = toScale;
        }

        public void SetPickedView()
        {
            _fire.gameObject.SetActive(true);
        }

        public void SetNormalView()
        {
            _fire.gameObject.SetActive(false);
        }
    }
}