const signIn = async () => {
    const userRegisterDetails = {
        userName: document.getElementById("userName").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
   
    };
    const addUserRegister = await fetch('api/Users/register', {
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
    const userLoginDetails = {
        userName: document.getElementById("userNameLogin").value,
        password: document.getElementById("passwordLogin").value,
    };
    const getUserByUserNameAndPasswordLogin = await fetch('api/Users/logIn', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userLoginDetails)

    });
    const TheLoggedInUser = await getUserByUserNameAndPasswordLogin.json();
    console.log('login user:', TheLoggedInUser);
    localStorage.setItem("CurrentLoginUser", JSON.stringify(TheLoggedInUser));
    window.location.href = "UpdateUser.html"
};

const updateUser = async () => {
    const userUpdateDetails = {
        userName: document.getElementById("userNameUpdate").value,
        password: document.getElementById("passwordUpdate").value,
        firstName: document.getElementById("firstNameUpdate").value,
        lastName: document.getElementById("lastNameUpdate").value,
    };
    const userid =JSON.parse( localStorage.getItem("CurrentLoginUser")).userId;
    const UpdateUser = await fetch(`api/Users/${userid}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userUpdateDetails)
    });
    const TheUpdatedUser = await UpdateUser.json();
    console.log('update user data:', TheUpdatedUser)

}

