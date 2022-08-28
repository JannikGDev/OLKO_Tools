using UnityEngine;
using UnityEngine.UI;

namespace Tests.Runtime.EventSystemTest
{
    [RequireComponent(typeof(Text))]
    public class ActionChangeText : MonoBehaviour
    {
        [SerializeField]
        [TextArea]
        private string TextToChangeTo;

        public void ChangeText()
        {
            this.GetComponent<Text>().text = TextToChangeTo;
        }
    }
}
