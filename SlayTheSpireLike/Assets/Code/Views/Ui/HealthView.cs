using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Views.Ui
{
    public class HealthView: MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private TMP_Text _armor;
        [SerializeField] private TMP_Text _healthText;
        public void UpdateUi(float maxHp, float currentHp, int armor)
        {
            _healthSlider.value = currentHp / maxHp;
            _armor.text = armor.ToString();
            _healthText.text = currentHp + "/" + maxHp;
        }
    }
}