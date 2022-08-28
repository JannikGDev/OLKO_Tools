using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tests.Runtime.SceneLoadingTest
{
    public class ActionSetTMPText : MonoBehaviour
    {
        [SerializeField] private TMP_Text textObject;
        
        public void Action_SetTMPText(string text)
        {
            textObject.text = text;
        }
    }
}
