using UnityEngine;
using UnityEngine.UI;

public class LivesDisplay : MonoBehaviour
{
    // Cached References
    Text LivesText;

    [SerializeField] int lives = 4;
    [SerializeField] int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        LivesText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        LivesText.text = lives.ToString();
    }

    public void LoseLife()
    {
        lives-= damage;
        UpdateDisplay();
        if(lives <= 0)
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            //FindObjectOfType<ScreenLoader>().LoadYouLose();
        }
    }
}

