using TMPro;
using UnityEngine;

namespace Code.Views.Ui
{
    public class EnergyView: MonoBehaviour
    {
        [SerializeField] private TMP_Text _energy;
        public void UpdateUi(int curent)
        {
            _energy.text = curent.ToString();
        }
    }
}