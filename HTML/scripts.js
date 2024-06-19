///Trips.com JS///

const BASE_URL = "http://localhost:5029";
let current_user = {};

// User Container Div
const userContainerDiv = document.querySelector("#user-container");
const loginContainerDiv = document.querySelector("#login-container");
const addUserContainerDiv = document.querySelector("#register-container");
//const addUserContainerDiv = document.querySelector("#add-user-container");
const currentUserContainer = document.querySelector("#current-user");
const userInfoContainer = document.querySelector("#user-info-container");

////////////////////////////////
//////////  Login   ///////////
///////////////////////////////

// GenerateLoginContainer();
// GenerateAddUserContainer();

// // Login Container Creation Function
// function GenerateLoginContainer() {
//   // Create the main login container div
//   let loginContainerDiv = document.createElement("div");

//   loginContainerDiv.id = "login-container";

//   let loginHeader = document.createElement("h3");
//   loginHeader.textContent = "Login";

//   let lineBreak = document.createElement("br");
//   lineBreak.id = "line-break";

//   let usernameInput = document.createElement("input");
//   usernameInput.type = "text";
//   usernameInput.id = "username-login-input";

//   let usernameInputLabel = document.createElement("label");
//   usernameInputLabel.textContent = "Username";

//   let passwordInput = document.createElement("input");
//   passwordInput.type = "password";
//   passwordInput.id = "password-login-input";

//   let passwordInputLabel = document.createElement("label");
//   passwordInputLabel.textContent = "Password";
//   passwordInputLabel.set;

//   // Create the login button
//   let loginButton = document.createElement("button");
//   loginButton.textContent = "Login";

//   // Add an event listener to the login button to handle login
//   loginButton.addEventListener("click", GetLoginInformation);

//   // Append the login container to the main user container
//   userContainerDiv.appendChild(loginContainerDiv);

//   // Append the username and password fields and labels to the login container
//   loginContainerDiv.appendChild(loginHeader);
//   loginContainerDiv.appendChild(usernameInputLabel);
//   loginContainerDiv.appendChild(usernameInput);
//   loginContainerDiv.appendChild(lineBreak);
//   loginContainerDiv.appendChild(passwordInputLabel);
//   loginContainerDiv.appendChild(passwordInput);
//   loginContainerDiv.appendChild(loginButton);
// }

//TODO: fix this function so that it actually works
function TeardownLoginContainer() {
  if (loginContainerDiv != null) {
    while (loginContainerDiv.firstChild) {
      loginContainerDiv.firstChild.remove();
    }
  }
}
// event listener to the login button to handle login
let loginButton = document.querySelector("#login-button");
loginButton.addEventListener("click", GetLoginInformation);

//Function to get login information from input fields
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
    GenerateCurrentUserContainer(current_user);
    GenerateUserInfoContainer(current_user);
    return current_user;
  } catch (e) {
    console.error("Error logging in:", e); // Added error logging
  }
  // TeardownLoginContainer();
}

////////////////////////////////
///////// Add User   ///////////
///////////////////////////////

// Add User Container Creation Function
// function GenerateAddUserContainer() {
//   let addUserHeader = document.createElement("h3");
//   addUserHeader.textContent = "Create an Account";

//   let addUserContainerDiv = document.createElement("div");
//   addUserContainerDiv.id = "add-user-container";

//   // Create the First Name input field and label
//   let firstNameInput = document.createElement("input");
//   firstNameInput.type = "text";
//   firstNameInput.id = "firstName-input";

//   let firstNameInputLabel = document.createElement("label");
//   firstNameInputLabel.textContent = "First Name";

//   let lineBreak1 = document.createElement("br");

//   // Create the Last Name input field and label
//   let lastNameInput = document.createElement("input");
//   lastNameInput.type = "text";
//   lastNameInput.id = "lastName-input";

//   let lastNameInputLabel = document.createElement("label");
//   lastNameInputLabel.textContent = "Last Name";

//   let lineBreak2 = document.createElement("br");

//   // Create the User Name input field and label
//   let usernameInput = document.createElement("input");
//   usernameInput.type = "text";
//   usernameInput.id = "username-input";

//   let usernameInputLabel = document.createElement("label");
//   usernameInputLabel.textContent = "Username";

//   let lineBreak3 = document.createElement("br");

//   // Create the password input field and label
//   let passwordInput = document.createElement("input");
//   passwordInput.type = "password";
//   passwordInput.id = "password-input";

//   let passwordInputLabel = document.createElement("label");
//   passwordInputLabel.textContent = "Password";

//   let lineBreak4 = document.createElement("br");

//   // Create the max budget input field and label
//   let maxBudgetInputLabel = document.createElement("label");
//   maxBudgetInputLabel.textContent = "Max Budget";

//   let maxBudgetInput = document.createElement("input");
//   maxBudgetInput.type = "number";
//   maxBudgetInput.id = "maxBudget-input";

//   let lineBreak5 = document.createElement("br");

//   // Create the submit button
//   let addUserButton = document.createElement("button");
//   addUserButton.textContent = "Submit";

//   // Append the Add User container to the main user container
//   userContainerDiv.appendChild(addUserContainerDiv);

//   // Append the user fields and labels to the addUser container
//   addUserContainerDiv.appendChild(addUserHeader);
//   addUserContainerDiv.appendChild(firstNameInputLabel);
//   addUserContainerDiv.appendChild(firstNameInput);
//   addUserContainerDiv.appendChild(lineBreak1);
//   addUserContainerDiv.appendChild(lastNameInputLabel);
//   addUserContainerDiv.appendChild(lastNameInput);
//   addUserContainerDiv.appendChild(lineBreak2);
//   addUserContainerDiv.appendChild(usernameInputLabel);
//   addUserContainerDiv.appendChild(usernameInput);
//   addUserContainerDiv.appendChild(lineBreak3);
//   addUserContainerDiv.appendChild(passwordInputLabel);
//   addUserContainerDiv.appendChild(passwordInput);
//   addUserContainerDiv.appendChild(lineBreak4);
//   addUserContainerDiv.appendChild(maxBudgetInputLabel);
//   addUserContainerDiv.appendChild(maxBudgetInput);
//   addUserContainerDiv.appendChild(lineBreak5);
//   addUserContainerDiv.appendChild(addUserButton);

// Event listener to the addUser button to handle login
let addUserButton = document.querySelector("#register-button");
addUserButton.addEventListener("click", GetAddUserInformation);
// }

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
    GenerateUserInfoContainer(current_user);
    return current_user;
  } catch (Error) {
    console.error(Error);
  }
}

////////////////////////////////
///// Current User Info   //////
///////////////////////////////

function GenerateCurrentUserContainer(current_user) {
  let currentName = `${current_user.firstName} ${current_user.lastName}`;

  let currentUser = document.getElementById("current-user");
  currentUser.textContent = `Traveler: ${currentName}`;

  let usernameDisplay = document.getElementById("user-name");
  usernameDisplay.textContent = `${current_user.username}`;

  //TODO: Add the link to the user info page
  let userInfoLink = document.getElementById("updateUser-link");
  userInfoLink.href = "#";
  userInfoLink.textContent = "Update User Info";
}

//TODO: change the fields to editable text fields
function GenerateUserInfoContainer(current_user) {
  let userInfoContainer = document.getElementById("user-info-container");

  //   let userFirstName = document.createElement("input");
  //   userFirstName.type = "text";

  //   let userFirstNameLabel = document.createElement("label");
  //   userFirstNameLabel.textContent = "First Name: ";
  //   userFirstName.value = current_user.firstName;

  //   let userLastNameLabel = document.createElement("label");
  //   let userLastName = document.createElement("input");
  //   userLastName.type = "text";

  //   userLastNameLabel.textContent = "Last Name: ";
  //   userLastName.value = current_user.lastName;

  //   let userMaxBudget = document.createElement("p");
  //   userMaxBudget.textContent = `Max Budget: $${current_user.maxBudget}`;

  //   let userUserName = document.createElement("p");
  //   userUserName.textContent = `Username: ${current_user.username}`;

  //   let userPassword = document.createElement("p");
  //   userPassword.textContent = `Password: ${current_user.password}`;

  //   let userIsAdmin = document.createElement("p");
  //   userIsAdmin.textContent = `Admin: ${current_user.isAdmin}`;

  //   userInfoContainer.appendChild(userFirstNameLabel);
  //   userInfoContainer.appendChild(userFirstName);
  //   userInfoContainer.appendChild(userLastNameLabel);
  //   userInfoContainer.appendChild(userLastName);
  //   userInfoContainer.appendChild(userMaxBudget);
  //   userInfoContainer.appendChild(userUserName);
  //   userInfoContainer.appendChild(userPassword);
  //   userInfoContainer.appendChild(userIsAdmin);
  // }

  ////////////////////////////////
  //////SavedTrip Container///////
  ///////////////////////////////

  const savedtripscontainer = document.querySelector("#saved-trips-container");
  const savedtripslist = document.querySelector("#saved-trips-list");

  const inputNumber = savedtripscontainer.children[3];
  const searchButton = savedtripscontainer.children[4];
  const resetButton = savedtripscontainer.children[5]; //reset button


function GetSavedTripsByUserId() {
  let userId = inputNumber.value;
  getSavedTripsByUserIdFromDb(userId);
}

searchButton.addEventListener("click", GetSavedTripsByUserId);

async function getSavedTripsByUserIdFromDb(userId) {
  const URL = `${BASE_URL}/SavedTrip/${userId}`; //concatenated version of  http://localhost:5029/SavedTrip/1
  try {
    let response = await fetch(URL);
    let data = await response.json();
    console.log(data); //sanity check
    displaySavedTrips(data); //trying to figure out how to convert the string that is coming back to something that can display??
  } catch (Error) {
    console.error(Error);
  }
}
/////////////////////////////////////////////
//////////// Display Saved Trips ////////////
/////////////////////////////////////////////

//Empty Container for Saved Trips - this should be correct
//next to cuntion displaySavedTrips we need to have what should be displayed like the trip name, location, etc. I just can't figure out exactly how to do that.
async function displaySavedTrips(savedtripdatas) {
  savedtripslist.innerHTML = "";
  for (const savedtripdata of savedtripdatas) {
    const option = document.createElement("option");
    const tripdata = await fetchTripFromDB(savedtripdata.tripId);
    option.text = tripdata.tripName;
    option.value = savedtripdata.UId;
    savedtripslist.add(option);
  }
  savedtripslist.size = Object.keys(savedtripdatas).length;
}

async function deleteSavedTripByID() {
  const selected = savedtripslist.value;
  const tripdata = await deleteSavedTripFromDB(selected);
  GetSavedTripsByUserId(); 
}

async function deleteSavedTripFromDB(savedtripId) {
  const URL = `${BASE_URL}/SavedTrip/${savedtripId}`;
  try {
    let response = await fetch(URL, {
      method: 'DELETE',
    })  
    let data = await response.json();
    console.log(data);
    
    return data;

  } catch (Error) {
    console.error(Error);
  }
}

/////////////////////////////////
////////Reset Button //////////// - clears the input field - works!!
/////////////////////////////////

resetButton.addEventListener("click", function () {
  inputNumber.value = "";
  savedtripslist.innerHTML = "";
});

// Trip Container Div
const tripContainerDiv = document.querySelector("#trip-container");
//const tripList = document.querySelector("#tripListContainer");
const tripList = document.querySelector("#ListOfTrips");
//const createTripContainerDiv = document.querySelector("#create-trip-container");
//const updateTripContainerDiv = document.querySelector("#update-trip-container");
const tripDetails = document.querySelector("#TripDetails");

console.log(tripList);

//async function to actually communicate with the trip api
// function that takes in the search input for the search container

async function getTrips() {
  const URL = `${BASE_URL}/Trip`;
  try {
    let response = await fetch(URL);
    let data = await response.json();
    console.log(data);
    displayTrips(data);
  } catch (error) {
    console.error(error);
  }
}
getTrips();

function showTrip(trip) {
  let triphtml = "";
  triphtml += "<p>Selected Trip: " + trip.tripName + "</p>";
  triphtml += "<p>Destination: " + trip.locationName + "</p>";
  triphtml += "<p>Travel Type: " + trip.travelTypeName + "</p>";
  triphtml += "<p>Climate: " + trip.climateType + "</p>";
  triphtml += "<p>Passport Required: " + trip.needsPassport + "</p>";
  triphtml += "<p>Included Activity: " + trip.activityName + "</p>";
  triphtml +=
    "<p>Total Cost: $" + trip.maxBudget + " all-inclusive!" + "</p>";

  // TODO: the rest of the fields
  // triphtml += JSON.stringify(trip);
  return triphtml;
}

function displayTripDetails(data) {
  //{ need to work through this
  tripDetails.innerHTML = "";
  tripDetails.innerHTML = showTrip(data);
}
async function getTripByID() {
  const selected = tripList.value;
  const tripdata = await fetchTripFromDB(selected);
  displayTripDetails(tripdata); //need to work through this
}

async function fetchTripFromDB(tripId) {
  const URL = `${BASE_URL}/Trip/${tripId}`;
  try {
    let response = await fetch(URL);
    let data = await response.json();
    console.log(data);
    
    return data;

  } catch (Error) {
    console.error(Error);
  }

  // function showTrip(trip) {
  //   let triphtml = "";
  //   // triphtml += JSON.stringify(trip);

 

  function displayTrips(tripDatas) {
    for (const tripData of tripDatas) {
      const option = document.createElement("option");
      option.text = tripData.tripName;
      option.value = tripData.tripId;
      tripList.add(option);

      //tripList.appendChild(document.createTextNode(element.tripName));
    }
    tripList.size = Object.keys(tripDatas).length;
  }

  function getTripByID() {
    const selected = tripList.value;
    fetchTripFromDB(selected);
  }


  async function fetchTripFromDB(tripId) {
    const URL = `${BASE_URL}/Trip/${tripId}`;
    try {
      let response = await fetch(URL);
      let data = await response.json();
      console.log(data);
      displayTripDetails(data); //need to work through this
    } catch (Error) {
      console.error(Error);
    }

