using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health health;
    private Image image;
    private void Start()
    {
        image = GetComponent<Image>();
        if (image)
            if (image.type != Image.Type.Filled)
                Debug.Log("Health bar must be used with an Image set to Filled Image Type");
        else
            Debug.Log("Gameobject: " + gameObject.name + "has HealthBar but no Image component");
    }
    private void Update()
    {
        image.fillAmount = health.Percent;
    }
}