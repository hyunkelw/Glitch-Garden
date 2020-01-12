using UnityEngine;
using UnityEngine.UI;


public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = .55f;

    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultDifficulty = 1f;


    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.getVolume();
        difficultySlider.value = PlayerPrefsController.getDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.Log("No music player found! Did you start from the splash screen?");
        }
        
    }

    public void SaveAndExit()
    {
        Debug.Log("saving master value at.. " + volumeSlider.value);
        PlayerPrefsController.setVolume(volumeSlider.value);
        Debug.Log("saving difficulty at.. " + difficultySlider.value);
        PlayerPrefsController.setDifficulty(difficultySlider.value);
        FindObjectOfType<ScreenLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }

}
