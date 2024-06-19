///Trips.com JS///

const BASE_URL = "http://localhost:5029";
let current_user = {};
let current_trip = {};

// User Container Div
const userContainerDiv = document.querySelector("#landing-user-container");
const loginContainerDiv = document.querySelector("#login-container");
const addUserContainerDiv = document.querySelector("#register-container");
const currentUserContainer = document.querySelector("#current-user");
const userInfoContainer = document.querySelector("#user-info-container");
const savedTripButton = document.querySelector("#saved-Trip-Button");

////////////////////////////////
//////////  Login   ///////////
///////////////////////////////

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
    getSavedTripsByUserIdFromDb(current_user.userId);
    LoginCheck();
    AdminCheck();
    return current_user;
  } catch (e) {
    console.error(e);
    document.getElementById("login-error").textContent = "Invalid Username or Password";

  }
  // TeardownLoginContainer();
}
// hide the login container
function LoginCheck() {
  if (current_user == null) {
    document.querySelector("#current-user-container").hidden = true;
    document.querySelector("#features-container").hidden = true;
    document.querySelector("#landing-user-container").hidden = false;
  } else {
    document.querySelector("#current-user-container").hidden = false;
    document.querySelector("#landing-user-container").hidden = true;
    document.querySelector("#features-container").hidden = false;
  }
}
function AdminCheck() {
  if (current_user.isAdmin) {
    document.querySelector("#createTripContainer").hidden = false;
  } else {
    document.querySelector("#createTripContainer").hidden = true;
  }
}

const handleLogout = () => {
  window.localStorage.clear();
  window.location.reload(true);
  // window.location.replace('/');
};

////////////////////////////////
///////// Add User   ///////////
///////////////////////////////

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
  let isAdmin = document.querySelector("#isAdmin-input").value;

  AddUser(username, password, firstName, lastName, maxBudget, isAdmin);
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
///// Current User Header  //////
///////////////////////////////

function GenerateCurrentUserContainer(current_user) {
  let currentName = `${current_user.firstName} ${current_user.lastName}`;

  let currentUser = document.getElementById("current-user");
  currentUser.textContent = `Traveler: ${currentName}`;

  let usernameDisplay = document.getElementById("user-name");
  usernameDisplay.textContent = `${current_user.username}`;

  let logoutButton = document.querySelector("#logout-button");
  logoutButton.addEventListener("click", handleLogout);
}

////////////////////////////////
///// User Info Container  //////
///////////////////////////////

function GenerateUserInfoContainer(current_user) {
  let firstNameDisplay = document.getElementById("firstName-update-input");
  firstNameDisplay.value = current_user.firstName;

  let lastNameDisplay = document.getElementById("lastName-update-input");
  lastNameDisplay.value = current_user.lastName;

  let usernameDisplay = document.getElementById("username-update-input");
  usernameDisplay.value = current_user.username;

  let passwordDisplay = document.getElementById("password-update-input");
  passwordDisplay.value = current_user.password;

  let maxBudgetDisplay = document.getElementById("maxBudget-update-input");
  maxBudgetDisplay.value = current_user.maxBudget;

  let isAdminDisplay = document.getElementById("isAdmin-update-input");
  isAdminDisplay.value = current_user.isAdmin;
}
// Event listener to the addUser button to handle login
let updateUserButton = document.querySelector("#updateUser-button");
updateUserButton.addEventListener("click", GetUpdateUserInformation);
// }
//TODO: change the fields to editable text fields
function GetUpdateUserInformation() {
  let firstName = document.getElementById("#firstName-update-input").value;
  let lastName = document.getElementById("#lastName-update-input").value;
  let username = document.getElementById("#username-update-input").value;
  let password = document.getElementById("#password-update-input").value;
  let maxBudget = document.getElementById("#maxBudget-update-input").value;

  UpdateUser(username, password, firstName, lastName, maxBudget);
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

function GetSavedTripsByUserId() {
  let userId = inputNumber.value;
  getSavedTripsByUserIdFromDb(userId);
}

// searchButton.addEventListener("click", GetSavedTripsByUserId);

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
  for await (const savedtripdata of savedtripdatas) {
    const option = document.createElement("option");
    const tripdata = await fetchTripFromDB(savedtripdata.tripId);
    option.text = tripdata.tripName;
    option.value = savedtripdata.uId;
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
      method: "DELETE",
    });
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

function displayTrips(tripDatas) {
  for (const tripData of tripDatas) {
    const option = document.createElement("option");
    option.text = tripData.tripName;
    option.value = tripData.tripId;
    tripList.add(option);
  }
  tripList.size = Object.keys(tripDatas).length;
}
function showTrip(trip) {
  let triphtml = "";
  triphtml += "<p>Selected Trip: " + trip.tripName + "</p>";
  triphtml += "<p>Destination: " + trip.locationName + "</p>";
  triphtml += "<p>Travel Type: " + trip.travelTypeName + "</p>";
  triphtml += "<p>Climate: " + trip.climateType + "</p>";
  triphtml += "<p>Passport Required: " + trip.needsPassport + "</p>";
  triphtml += "<p>Included Activity: " + trip.activityName + "</p>";
  triphtml += "<p>Total Cost: $" + trip.maxBudget + " all-inclusive!" + "</p>";
  return triphtml;
}

function displayTripDetails(data) {
  tripDetails.innerHTML = "";
  tripDetails.innerHTML = showTrip(data);
  savedTripButton.style.display = "block";
}

async function getTripByID() {
  const selected = tripList.value;
  const tripdata = await fetchTripFromDB(selected);
  displayTripDetails(tripdata);
}

async function fetchTripFromDB(tripId) {
  const URL = `${BASE_URL}/Trip/${tripId}`;
  try {
    let response = await fetch(URL);
    let data = await response.json();
    current_trip = data;
    console.log(data);   
     return data;
  } catch (Error) {
    console.error(Error);
  }
}

  async function SaveCurrentTrip() {
    try {
      let response = await fetch(`${BASE_URL}/SavedTrip`, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({

          TripId: current_trip.tripId,
          UserId: current_user.userId,
          Season: current_trip.season,
          Location: current_trip.location,
          MaxBudget: current_trip.maxBudget,
          TravelType: current_trip.travelType,
          PassportStatus: current_trip.passportStatus
        }),
      }); 
      let data = await response.json();  
      getSavedTripsByUserIdFromDb(current_user.userId);
      return data;
    } catch (e) {
      console.error("Error saving current trip: ", e); 
    }
  }

