using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Windows;
public class MenuScript : MonoBehaviour
{
    public GameObject Home;
    public GameObject Skills;
    public GameObject Ervaring;
    public GameObject School;
    public GameObject Hobbies;

    private Button HomeButton;
    private Button SkillsButton;
    private Button ErvaringButton;
    private Button SchoolButton;
    private Button HobbiesButton;

    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        HomeButton = root.Q<Button>("B_Home");
        SkillsButton = root.Q<Button>("B_Skills");
        ErvaringButton = root.Q<Button>("B_Ervaring");
        SchoolButton = root.Q<Button>("B_School");
        HobbiesButton = root.Q<Button>("B_Hobbies");

        root.Q<Button>("Git").clicked += OnGitBUtton;
        root.Q<Button>("Tel").clicked += OnTelButton;
        root.Q<Button>("Email").clicked += OnEmailButton;

        HomeButton.clicked += OnHomeButton;
        SkillsButton.clicked += OnSkillsButton;
        ErvaringButton.clicked += OnErvaringButton;
        SchoolButton.clicked += OnSchoolButton;
        HobbiesButton.clicked += OnHobbiesButton;
    }

    private void OnHomeButton()
    {
        HideAll();
        Home.SetActive(true);
    }
    private void OnSkillsButton()
    {
        HideAll();
        Skills.SetActive(true);
    }
    private void OnErvaringButton()
    {
        HideAll();
        Ervaring.SetActive(true);
    }
    private void OnSchoolButton()
    {
        HideAll();
        School.SetActive(true);
    }
    private void OnHobbiesButton()
    {
        HideAll();
        Hobbies.SetActive(true);
    }

    private void OnGitBUtton()
    {
        string str = "https://github.com/ThatGhost";
        GUIUtility.systemCopyBuffer = str;
    }

    private void OnTelButton()
    {
        //copy
        string str = "+3271234413";
        GUIUtility.systemCopyBuffer = str;
    }

    private void OnEmailButton()
    {
        //copy
        string str = "izwackaert@gmail.com";
        GUIUtility.systemCopyBuffer = str;
    }

    private void HideAll()
    {
        Home.SetActive(false);
        Skills.SetActive(false);
        Ervaring.SetActive(false);
        School.SetActive(false);
        Hobbies.SetActive(false);
    }
}
