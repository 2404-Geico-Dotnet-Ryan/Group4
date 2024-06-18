///Trips.com JS///

const BASE_URL = "http://localhost:5029";
let current_user = {};

// User Container Div
const userContainerDiv = document.querySelector("#user-container");
const loginContainerDiv = document.querySelector("#login-container");
const addUserContainerDiv = document.querySelector("#add-user-container");
const currentUserContainer = document.querySelector("#current-user");
const userInfoContainer = document.querySelector("#user-info-container");

// Trip Container Div
const tripContainerDiv = document.querySelector("#trip-container");
const createTripContainerDiv = document.querySelector("#create-trip-container");
const updateTripContainerDiv = document.querySelector("#update-trip-container");

////////////////////////////////
//////////  Login   ///////////
///////////////////////////////

GenerateLoginContainer();
GenerateAddUserContainer();

// Login Container Creation Function
function GenerateLoginContainer() {
  // Create the main login container div
  let loginContainerDiv = document.createElement("div");

  loginContainerDiv.id = "login-container";

  let loginHeader = document.createElement("h3");
  loginHeader.textContent = "Login";

  let lineBreak = document.createElement("br");
  lineBreak.id = "line-break";

  let usernameInput = document.createElement("input");
  usernameInput.type = "text";
  usernameInput.id = "username-login-input";

  let usernameInputLabel = document.createElement("label");
  usernameInputLabel.textContent = "Username";

  let passwordInput = document.createElement("input");
  passwordInput.type = "password";
  passwordInput.id = "password-login-input";

  let passwordInputLabel = document.createElement("label");
  passwordInputLabel.textContent = "Password";
  passwordInputLabel.set;

  // Create the login button
  let loginButton = document.createElement("button");
  loginButton.textContent = "Login";

  // Add an event listener to the login button to handle login
  loginButton.addEventListener("click", GetLoginInformation);

  // Append the login container to the main user container
  userContainerDiv.appendChild(loginContainerDiv);

  // Append the username and password fields and labels to the login container
  loginContainerDiv.appendChild(loginHeader);
  loginContainerDiv.appendChild(usernameInputLabel);
  loginContainerDiv.appendChild(usernameInput);
  loginContainerDiv.appendChild(lineBreak);
  loginContainerDiv.appendChild(passwordInputLabel);
  loginContainerDiv.appendChild(passwordInput);
  loginContainerDiv.appendChild(loginButton);
}

//TODO: fix this function so that it actually works
function TeardownLoginContainer() {
  if (loginContainerDiv != null) {
    while (loginContainerDiv.firstChild) {
      loginContainerDiv.firstChild.remove();
    }
  }
}

// Function to get login information from input fields
function GetLoginInformation() {
  let username = document.querySelector("#username-login-input").value;
  let password = document.querySelector("#password-login-input").value;

  LoginUser(username, password);
}

// Function to log in the user
async function LoginUser(username, password) {
  try {
    let response = await fetch(`${BASE_URL}/User/login`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        Username: username,
        Password: password,
      }),
    });

    let data = await response.json();
    current_user = data;
    console.log(current_user);
    TeardownLoginContainer();
    GenerateCurrentUserContainer(current_user);
    //GenerateUserInfoContainer(current_user);
  } catch (e) {
    console.error("Error logging in:", e); // Added error logging
  }
}

////////////////////////////////
///////// Add User   ///////////
///////////////////////////////

// Add User Container Creation Function
function GenerateAddUserContainer() {
  let addUserHeader = document.createElement("h3");
  addUserHeader.textContent = "Create an Account";

  let addUserContainerDiv = document.createElement("div");
  addUserContainerDiv.id = "add-user-container";

  // Create the First Name input field and label
  let firstNameInput = document.createElement("input");
  firstNameInput.type = "text";
  firstNameInput.id = "firstName-input";

  let firstNameInputLabel = document.createElement("label");
  firstNameInputLabel.textContent = "First Name";

  let lineBreak1 = document.createElement("br");

  // Create the Last Name input field and label
  let lastNameInput = document.createElement("input");
  lastNameInput.type = "text";
  lastNameInput.id = "lastName-input";

  let lastNameInputLabel = document.createElement("label");
  lastNameInputLabel.textContent = "Last Name";

  let lineBreak2 = document.createElement("br");

  // Create the User Name input field and label
  let usernameInput = document.createElement("input");
  usernameInput.type = "text";
  usernameInput.id = "username-input";

  let usernameInputLabel = document.createElement("label");
  usernameInputLabel.textContent = "Username";

  let lineBreak3 = document.createElement("br");

  // Create the password input field and label
  let passwordInput = document.createElement("input");
  passwordInput.type = "password";
  passwordInput.id = "password-input";

  let passwordInputLabel = document.createElement("label");
  passwordInputLabel.textContent = "Password";

  let lineBreak4 = document.createElement("br");

  // Create the max budget input field and label
  let maxBudgetInputLabel = document.createElement("label");
  maxBudgetInputLabel.textContent = "Max Budget";

  let maxBudgetInput = document.createElement("input");
  maxBudgetInput.type = "number";
  maxBudgetInput.id = "maxBudget-input";

  let lineBreak5 = document.createElement("br");

  // Create the submit button
  let addUserButton = document.createElement("button");
  addUserButton.textContent = "Submit";

  // Append the Add User container to the main user container
  userContainerDiv.appendChild(addUserContainerDiv);

  // Append the user fields and labels to the addUser container
  addUserContainerDiv.appendChild(addUserHeader);
  addUserContainerDiv.appendChild(firstNameInputLabel);
  addUserContainerDiv.appendChild(firstNameInput);
  addUserContainerDiv.appendChild(lineBreak1);
  addUserContainerDiv.appendChild(lastNameInputLabel);
  addUserContainerDiv.appendChild(lastNameInput);
  addUserContainerDiv.appendChild(lineBreak2);
  addUserContainerDiv.appendChild(usernameInputLabel);
  addUserContainerDiv.appendChild(usernameInput);
  addUserContainerDiv.appendChild(lineBreak3);
  addUserContainerDiv.appendChild(passwordInputLabel);
  addUserContainerDiv.appendChild(passwordInput);
  addUserContainerDiv.appendChild(lineBreak4);
  addUserContainerDiv.appendChild(maxBudgetInputLabel);
  addUserContainerDiv.appendChild(maxBudgetInput);
  addUserContainerDiv.appendChild(lineBreak5);
  addUserContainerDiv.appendChild(addUserButton);

  // Add an event listener to the addUser button to handle login
  addUserButton.addEventListener("click", GetAddUserInformation);
}

// Function to get User information from input fields
function GetAddUserInformation() {
  let username = document.querySelector("#username-input").value;
  let password = document.querySelector("#password-input").value;
  let firstName = document.querySelector("#firstName-input").value;
  let lastName = document.querySelector("#lastName-input").value;
  let maxBudget = document.querySelector("#maxBudget-input").value;

  AddUser(username, password, firstName, lastName, maxBudget);
}

// Function to create a new user
async function AddUser(username, password, firstName, lastName, maxBudget) {
  try {
    let response = await fetch(`${BASE_URL}/User`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        UserId: 0,
        Username: username,
        Password: password,
        FirstName: firstName,
        LastName: lastName,
        MaxBudget: maxBudget,
        IsAdmin: false,
      }),
    });
    let data = await response.json();
    current_user = data;
    console.log(current_user);
    GenerateCurrentUserContainer(current_user);
  } catch (Error) {
    console.error(Error);
  }
}

////////////////////////////////
///// Current User Info   //////
///////////////////////////////

//TODO: Add the Current User to the subheader of the page

// Get User Info by Username
// async function GetCurrentUser(username) {
//   try {
//     let response = await fetch(`${BASE_URL}/User/${username}`);
//     let userData = await response.json();
//     console.log(data);
//     return userData;
//   } catch (Error) {
//     console.error(Error);
//   }
// }

function GenerateCurrentUserContainer(current_user) {

  let currentUserName = `${current_user.FirstName} ${current_user.LastName}`;
  let currentUserContainer = document.createElement("h3");
  currentUserContainer.textContent = `Traveler: ${currentUserName}`;
  
  let lineBreak = document.createElement("br");

  let usernameDisplay = document.createElement("text");
  usernameDisplay.textContent = `${current_user.Username}`;


  let lineBreak2 = document.createElement("br");

  let userInfoLink = document.createElement("a");
  userInfoLink.href = "#"; //TODO: Add the link to the user info page
  userInfoLink.textContent = "Update User Info";

  //currentUserContainer.appendChild(currentUserName);
  currentUserContainer.appendChild(lineBreak);
  currentUserContainer.appendChild(usernameDisplay);
  currentUserContainer.appendChild(lineBreak2);
  currentUserContainer.appendChild(userInfoLink);
}

////////////////////////////////
//////SavedTrip Container///////
///////////////////////////////

const savedtripscontainer = document.querySelector("#saved-trips-container");
const savedtripslist = document.querySelector("#saved-trips-list");

const inputNumber = savedtripscontainer.children[3];
const searchButton = savedtripscontainer.children[4];
const resetButton = savedtripscontainer.children[5]; //reset button

console.log(inputNumber); //sanity check
console.log(searchButton); //sanity check
console.log(resetButton); //sanity check

function GetSavedTripByUserId() {
  let userId = inputNumber.value;
  getSavedTripByUserId(userId);
}

searchButton.addEventListener("click", GetSavedTripByUserId);

async function getSavedTripByUserId(userId) {
  const URL = `${BASE_URL}/SavedTrip/${userId}`; //concatenated version of  http://localhost:5029/SavedTrip/1
  try {
    let response = await fetch(URL);
    let data = await response.json();
    console.log(data); //sanity check
    displaySavedTrips(); //trying to figure out how to convert the string that is coming back to something that can display??
  } catch (Error) {
    console.error(Error);
  }
}
/////////////////////////////////////////////
//////////// Display Saved Trips ////////////
/////////////////////////////////////////////

//Empty Container for Saved Trips - this should be correct

async function displaySavedTrips() {
  while (savedtripslist.firstChild) {
    savedtripslist.removeChild(savedtripslist.firstChild);
  }

  // Create the saved trips list

  // Append the saved trips list to the saved trips container

  //savedtripslist.appendChild(not sure what to put here yet) - trying to figure out how to convert the string that is coming back to something that can display??;
}
/////////////////////////////////
////////Reset Button //////////// - clears the input field - works!!
/////////////////////////////////

resetButton.addEventListener("click", function () {
  inputNumber.value = "";
  savedtripslist.innerHTML = "";
});
