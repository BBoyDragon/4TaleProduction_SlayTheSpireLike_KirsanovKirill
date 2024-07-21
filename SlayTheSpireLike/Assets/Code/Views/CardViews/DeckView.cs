using UnityEngine;

namespace Code.Views.CardViews
{
    public class DeckView: MonoBehaviour
    {
        [SerializeField] private GameObject Card1;
        [SerializeField] private GameObject Card5;
        
        public void SetDeckView(int count)
        {
            if (count==0)
            {
                Card1.gameObject.SetActive(false);
                Card5.gameObject.SetActive(false);
                return;
            }
            if (count==1)
            {
                Card1.gameObject.SetActive(true);
                Card5.gameObject.SetActive(false);
                return;
            }
            if(count>1)
            {
                Card1.gameObject.SetActive(false);
                Card5.gameObject.SetActive(true);
            }
        }
    }
}