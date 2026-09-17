using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health;
    [SerializeField] private Image healthImage;
    public bool alive;

    private void Update()
    {
        changeHealthBar();
    }
    public void changeHealthBar()
    {
        healthImage.fillAmount = health * 0.01f;
    }
    public void DamageTake(float amountDamage)
    {
        health -= amountDamage;

        if (health <= 0)
        {
            alive = false;
        }
    }
}
