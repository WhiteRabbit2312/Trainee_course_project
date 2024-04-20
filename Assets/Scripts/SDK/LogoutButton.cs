using UnityEngine;
using UnityEngine.EventSystems;
using Firebase.Auth;

public class LogoutButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        FirebaseAuth.DefaultInstance.SignOut();
    }
}
