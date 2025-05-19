const signIn = async () => {
    //const userRegisterDetails = {
    //    userName: document.querySelector("userName").value,
    //    password: document.querySelector("password").value,
    //    firstName: document.querySelector("firstName").value,
    //    lastName: document.querySelector("lastName").value,
    //     LastName = document.querySelector("lastName").value;


    //};

    const userName= document.querySelector("#userName").value
     const  password=document.querySelector("#password").value
         const   firstName=document.querySelector("#firstName").value
    const lastName = document.querySelector("#lastName").value
    const userRegisterDetails = {
        userName, password, firstName, lastName
        }
    console.log("hereeee2222", userName)
    console.log(userRegisterDetails);

    const addUserRegister = await fetch('api/User/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userRegisterDetails)
    });
    const TheSignedInUser = await addUserRegister.json();
    console.log('register', TheSignedInUser);
};

const logIn = async () => {
    const userName = document.querySelector("#userNameLogin").value;
    const password = document.querySelector("#passwordLogin").value;
    if (!userName || !password) {
        alert("username and password are required");
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


    console.log("userid");
    console.log(userid);
   
    const UpdateUser = await fetch(`api/User/${userid}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userUpdateDetails)
    });
    const TheUpdatedUser = await UpdateUser.json();
    console.log('update user data:', TheUpdatedUser)

}

