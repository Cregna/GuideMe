using UnityEngine;
using UnityEngine.UI;

public class third : MonoBehaviour
{
    Image m_Image;
    //Set this in the Inspector
    public Sprite m_Sprite;

    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
    }
    private void OnEnable()
    {
        RandomRoadChooser.updateUI += updateUI;
    }

    private void OnDisable()
    {
        RandomRoadChooser.updateUI -= updateUI;

    }
    public void updateUI() {
        m_Image.sprite = RandomRoadChooser.choose[2].icon;
    }
}
