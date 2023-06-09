using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class RageMeter : MonoBehaviour
    {
        public delegate void RageMeterFullAction(bool value);
        public static event RageMeterFullAction OnRageMeterFull;

        public void UpdateValue(float value)
        {
            if (value >= 1f)
                FireEvent(true);
            else
                FireEvent(false);
        }

        private void FireEvent(bool value)
        {
            if (OnRageMeterFull != null) OnRageMeterFull.Invoke(value);
        }


    }
}