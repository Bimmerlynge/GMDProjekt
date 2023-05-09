using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RunePanel : MonoBehaviour
    {
        [SerializeField] private Image attack, special, dash, rage;

        private void OnEnable()
        {
            RuneSelector.RuneSelectedEvent += SetRuneIcon;
        }

        public void SetRuneIcon(RuneSO rune)
        {
            var type = rune.type;
            switch (type)
            {
                case RuneSO.Type.Attack:
                    attack.sprite = rune.icon;
                    break;
                case RuneSO.Type.Special:
                    special.sprite = rune.icon;
                    break;
                case RuneSO.Type.Dash:
                    dash.sprite = rune.icon;
                    break;
                case RuneSO.Type.Rage:
                    rage.sprite = rune.icon;
                    break;
            }
        }
    }
}