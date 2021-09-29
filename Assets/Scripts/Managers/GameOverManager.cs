using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text warningText;
    public PlayerHealth playerHealth;       
    public float restartDelay = 5f;            


    Animator anim;                          
    private float restartTimer;                    
    private static readonly int GameOver = Animator.StringToHash("GameOver");
    private static readonly int Warning = Animator.StringToHash("Warning");

    void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger(GameOver);

            restartTimer += Time.deltaTime;

            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        warningText.text = $"{Mathf.RoundToInt(enemyDistance)} M!";
        anim.SetTrigger(Warning);
    }
}