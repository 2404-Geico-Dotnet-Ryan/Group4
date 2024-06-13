//SPA (Single Page Application)
//so that I can keep track of the users' information on the same script

const BASE_URL = "http://localhost:5029"; 
let current_user = {};

// User Container Div
const userContainerDiv = document.querySelector("#user-container");
const loginContainerDiv = document.querySelector("#login-container");
const addUserContainerDiv = document.querySelector("#add-user-container");

// Trip Container Div
//const tripContainerDiv = document.querySelector("#trip-container");
//const createTripContainerDiv = document.querySelector("#create-trip-container");
//const updateTripContainerDiv = document.querySelector("#update-trip-container");


// Add User Container Creation Function
function GenerateAddUserContainer() {
  // Create the add user container div
  let addUserDiv = document.createElement("div");
  addUserDiv.id = "add-user-container";

  // Create the First Name input field and label
  let firstNameInput = document.createElement("input");
  firstNameInput.type = "text";
  firstNameInput.id = "firstName-input";

  let firstNameInputLabel = document.createElement("label");
  firstNameInputLabel.textContent = "First Name";

  // Create the Last Name input field and label
  let lastNameInput = document.createElement("input");
  lastNameInput.type = "text";
  lastNameInput.id = "lastName-input";

  let lastNameInputLabel = document.createElement("label");
  lastNameInputLabel.textContent = "Last Name";

   // Create the User Name input field and label
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
  let addUserButton = document.createElement("button");
  addUserButton.textContent = "Submit";

  // Append the login container to the main user container
  addUserContainer.appendChild(addUserDiv);

  // Append the user fields and labels to the addUser container
  addUserDiv.appendChild(firstNameInputLabel);
  addUserDiv.appendChild(firstNameInput);
  addUserDiv.appendChild(lastNameInputLabel);
  addUserDiv.appendChild(lastNameInput);
  addUserDiv.appendChild(usernameInputLabel);
  addUserDiv.appendChild(usernameInput);
  addUserDiv.appendChild(passwordInputLabel);
  addUserDiv.appendChild(passwordInput);
  addUserDiv.appendChild(addUserButton);

  // Add an event listener to the addUser button to handle login
  addUserButton.addEventListener("click", AddUser);
}

//

// Function to create a new user
async function AddUser(
  firstName,
  lastName,
  username,
  password
) {
  try {
    let response = await fetch(`${BASE_URL}/Users`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        "UserId": -1,
        "Username": username,
        "Password": password,
        "FirstName": firstName,
        "LastName": lastName,
      }),
    });
    // let data = await response.json();
    // console.log(data);
    console.log(response);
    if (response.status === 201) {
      alert("User created successfully");
    } else {
      alert("Error creating user");
    }
    // Alerts are a good way test, but not great for production
    //return data;
  } catch (Error) {
    console.error(Error);
  }
}

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

// // Function to tear down the login container
// function TeardownLoginContainer() {
//   // Find the login container
//   let loginDiv = document.querySelector("#login-container");

//   // If the login container exists, remove all its children
//   if (loginDiv != null) {
//     while (loginDiv.firstChild) {
//       loginDiv.firstChild.remove();
//     }
//   }
// }

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
    let response = await fetch(`${BASE_URL}/User/login`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json", // Corrected the content type to 'application/json'
      },
      body: JSON.stringify({
        "Username": username,
        "Password": password,
      }),
    });

    let data = await response.json();
    current_user = data;
    console.log(current_user);
    TeardownLoginContainer();
    GenerateHomepageContainer(data);
  } catch (e) {
    console.error("Error logging in:", e); // Added error logging
  }
}

// Generate and tear down a login component
// GenerateLoginContainer();
// TeardownLoginContainer(); // Uncomment this line to tear down the login component

// Generate a User info component
//TODO: Change Homepage to the User info container and functionality
function GenerateHomepageContainer(userData) {
  let homePageContainer = document.querySelector("#home-page-container");

  while (homePageContainer.firstChild) {
    homePageContainer.firstChild.remove();
  }

  let userHeader = document.createElement("h2");
  let emailHeader = document.createElement("h3");

  userHeader.textContent = userData.Username;
  emailHeader.textContent = userData.Email;

  homePageContainer.appendChild(userHeader);
  homePageContainer.appendChild(emailHeader);
}

// teardown the homepage for the user
function tearDownHomePageContainer() {
  while (homePageContainer.firstChild) {
    homePageContainer.firstChild.remove();
  }
}

// // User Controller Functions

// async function GetAllUsers() {
//   try {
//     let response = await fetch(`${BASE_URL}/User`);
//     let data = await response.json();
//     console.log(data);
//     return data;
//   } catch (Error) {
//     console.error(Error);
//   }
// }

// async function GetUserById(id) {
//   try {
//     let response = await fetch(`${BASE_URL}/User/${id}`);
//     let data = await response.json();
//     console.log(data);
//     return data;
//   } catch (Error) {
//     console.error(Error);
//   }
// }
// Test these API calls as you are making them so that you can verify that it works inside your script before you actually use them in your website
// GetAllUsers();
// GetUserById(1);


