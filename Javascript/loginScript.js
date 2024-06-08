// I am going for an SPA (Single Page Application)
// This means I need functions that can be run to create entire components on the fly, and tear them down once I am done with them

// I want to do this, so that I can keep track of the users' information on the same script

// User Container Div
const userContainerDiv = document.querySelector(
  "#user-authorization-container"
);

// Login Container Creation Function
function GenerateLoginContainer() {
  // Create the main login container div
  let loginDiv = document.createElement("div");
  loginDiv.id = "login-container";

  // Create the username input field and label
  let usernameInput = document.createElement("input");
  usernameInput.type = "text";
  usernameInput.id = "username-input";

  let usernameInputLabel = document.createElement("label");
  usernameInputLabel.textContent = "Username";

  // Create the password input field and label
  let passwordInput = document.createElement("input");
  passwordInput.type = "password";
  passwordInput.id = "password-input";

  let passwordInputLabel = document.createElement("label");
  passwordInputLabel.textContent = "Password";

  // Create the login button
  let loginButton = document.createElement("button");
  loginButton.textContent = "Login";

  // Append the login container to the main user container
  userContainerDiv.appendChild(loginDiv);

  // Append the username and password fields and labels to the login container
  loginDiv.appendChild(usernameInputLabel);
  loginDiv.appendChild(usernameInput);
  loginDiv.appendChild(passwordInputLabel);
  loginDiv.appendChild(passwordInput);
  loginDiv.appendChild(loginButton);

  // Add an event listener to the login button to handle login
  loginButton.addEventListener("click", GetLoginInformation);
}

// Function to tear down the login container
function TeardownLoginContainer() {
  // Find the login container
  let loginDiv = document.querySelector("#login-container");

  // If the login container exists, remove all its children
  if (loginDiv != null) {
    while (loginDiv.firstChild) {
      loginDiv.firstChild.remove();
    }
  }
}

// Function to get login information from input fields
function GetLoginInformation() {
  let username = document.querySelector("#username-input").value;
  let password = document.querySelector("#password-input").value;

  // Call the function to log in the user
  LoginUser(username, password);
}

// Function to log in the user
async function LoginUser(username, password) {
  try {
    let response = await fetch("http://localhost:5236/Users/login", {
      method: "POST",
      headers: {
        "Content-Type": "application/json", // Corrected the content type to 'application/json'
      },
      body: JSON.stringify({
        Username: username,
        Password: password,
      }),
    });

    let data = await response.json();
    console.log(data);
  } catch (e) {
    console.error("Error logging in:", e); // Added error logging
  }
}

// Generate and tear down a login component
GenerateLoginContainer();
// TeardownLoginContainer(); // Uncomment this line to tear down the login component
