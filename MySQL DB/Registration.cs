using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    public InputField nicknameInput;
    public InputField passwordInput;
    public InputField emailInput;
    public Button signupButton;

    public DatabaseManager databaseManager;

    private void Start()
    {
        // Make sure databaseManager is assigned before proceeding
        if (databaseManager == null)
        {
            Debug.LogError("DatabaseManager is not assigned. Make sure it is attached to a GameObject and referenced in the Inspector.");
            return;
        }

        Debug.Log("Registration script Start() method is called.");
        // databaseManager = GetComponent<DatabaseManager>();
        signupButton.interactable = false; // Disable the signup button initially
    }

    public void OnNicknameChanged()
    {
        CheckSignupInput();
    }

    public void OnPasswordChanged()
    {
        CheckSignupInput();
    }

    public void OnEmailChanged()
    {
        CheckSignupInput();
    }

    private void CheckSignupInput()
    {
        bool isNicknameValid = nicknameInput.text.Length >= 4 && nicknameInput.text.Length <= 25;
        bool isPasswordValid = passwordInput.text.Length >= 8 && passwordInput.text.Length <= 25;
        bool isEmailValid = emailInput.text.Length >= 4 && emailInput.text.Length <= 25;

        signupButton.interactable = isNicknameValid && isPasswordValid && isEmailValid;
    }

    public void OnSignupButtonClicked()
    {
        string nickname = nicknameInput.text;
        string password = passwordInput.text;
        string email = emailInput.text;

        // Call the InsertData method from the DatabaseManager to insert the signup data into the database
        databaseManager.InsertData(nickname, password, email);

        // Optionally, you can add a message to inform the user that signup was successful
        Debug.Log("Signup successful!");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}