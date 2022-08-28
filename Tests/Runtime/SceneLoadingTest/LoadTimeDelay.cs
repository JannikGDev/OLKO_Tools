using UnityEngine;

namespace Tests.Runtime.SceneLoadingTest
{
    public class LoadTimeDelay : MonoBehaviour
    {
        [SerializeField]
        GameObject _object;
        
        // Start is called before the first frame update
        void Start()
        {
            for (int i = 0; i < 100000; i++)
            {
                GameObject.Instantiate(_object, Random.onUnitSphere * Random.Range(10, 100), Quaternion.identity);
            }
           
        }
    }
}
