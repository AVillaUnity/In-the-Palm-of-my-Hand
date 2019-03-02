using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{

    public Image currentImage;
    public GameObject backButton;
    public TextMeshProUGUI nextText;
    public Sprite[] tutorialImages;

    private int imageIndex = 0;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        currentImage.sprite = tutorialImages[imageIndex];
        gameManager = GameObject.FindObjectOfType<GameManager>();
        backButton.SetActive(false);
    }

    public void Next()
    {
        imageIndex++;
        CheckButtons();
        if (imageIndex >= tutorialImages.Length)
        {
            gameManager.LoadLevel("Game");
        }
        else
        {
            currentImage.sprite = tutorialImages[imageIndex];
        }
    }

    public void Back()
    {
        imageIndex--;
        CheckButtons();
        currentImage.sprite = tutorialImages[imageIndex];
    }

    void CheckButtons()
    {
        if(imageIndex <= 0)
        {
            backButton.SetActive(false);
        }
        else
        {
            backButton.SetActive(true);
        }

        if (imageIndex >= tutorialImages.Length - 1)
        {
            nextText.text = "Play";
        }
        else
        {
            nextText.text = "Next";
        }
    }
}
