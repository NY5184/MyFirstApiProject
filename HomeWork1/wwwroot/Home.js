const signIn = async () => {
    //const userRegisterDetails = {
    //    userName: document.querySelector("userName").value,
    //    password: document.querySelector("password").value,
    //    firstName: document.querySelector("firstName").value,
    //    lastName: document.querySelector("lastName").value,
    //     LastName = document.querySelector("lastName").value;


    //};

    const userName = document.querySelector("#userName").value
    const password = document.querySelector("#password").value
    const firstName = document.querySelector("#firstName").value
    const lastName = document.querySelector("#lastName").value
    if (!userName || !password || !firstName || !lastName) {
        alert("All fields are required!");
        return;
    }
    const userRegisterDetails = {
        userName, password, firstName, lastName
    }
    console.log("hereeee2222", userName)
    console.log(userRegisterDetails);
    try {
        const addUserRegister = await fetch('api/User/register', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userRegisterDetails)
        });
        if (!addUserRegister.ok) {
            const errorData = await addUserRegister.json();
            alert("Error: " + (errorData.message || "Registration failed"));
            return;
        }
        const TheSignedInUser = await addUserRegister.json();
        console.log('register', TheSignedInUser);
    }
    catch (error) {
        console.error("Error:", error);
        alert("An error occurred while registering. Please try again later.");
    }
    };

const logIn = async () => {
    const userName = document.querySelector("#userNameLogin").value;
    const password = document.querySelector("#passwordLogin").value;
    if (!userName || !password) {
        alert("username and password are required");
        return;
    }
    const userLoginDetails = {
        userName,
        password
    };
    
        const getUserByUserNameAndPasswordLogin = await fetch('api/User/logIn', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userLoginDetails)

        });

    if (!getUserByUserNameAndPasswordLogin.ok) {
        const errorMessage = await getUserByUserNameAndPasswordLogin.text();
  
        alert("Login failed: " + errorMessage);
        return;
    }
    if (getUserByUserNameAndPasswordLogin.status === 404) {
        alert("User not found or incorrect password");
        return;
    }

        const TheLoggedInUser = await getUserByUserNameAndPasswordLogin.json();
        console.log('login user:', TheLoggedInUser);
    localStorage.setItem("CurrentLoginUser", JSON.stringify(TheLoggedInUser));
    console.log("Saved user to localStorage:", TheLoggedInUser);

        window.location.href = "UpdateUser.html"
        console.log("CurrentLoginUser");
        console.log(JSON.parse(localStorage.getItem("CurrentLoginUser")))
    };

const updateUser = async () => {
    console.log("CurrentLoginUser");
    
    const userUpdateDetails = {

        userName: document.querySelector("#userNameUpdate").value,
        password: document.querySelector("#passwordUpdate").value,
        firstName: document.querySelector("#firstNameUpdate").value,
        lastName: document.querySelector("#lastNameUpdate").value,
    };
  
    const currentUser = JSON.parse(localStorage.getItem("CurrentLoginUser"));
    if (!currentUser) {
        alert("User is not logged in.");
        return;
    }
    const userid = currentUser.id;
    if (!userid) {
        alert("User ID is missing.");
        return;
    }

    console.log("userid");
    console.log(userid);
   
    try {
        const UpdateUser = await fetch(`api/User/${userid}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(userUpdateDetails)
        });

        if (!UpdateUser.ok) {
            const error = await UpdateUser.text();
            alert("Update failed: " + error);
            return;
        }

        const TheUpdatedUser = await UpdateUser.json();
        console.log('Updated user data:', TheUpdatedUser);
        alert("User updated successfully!");
    } catch (error) {
        console.error("Error during update:", error);
        alert("Something went wrong during update.");
    }
   

}

