using UnityEngine;

namespace TraineeGame
{
    public class Border : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Obstacle")
            {
                other.gameObject.SetActive(false);
            }
        }
    }
}
