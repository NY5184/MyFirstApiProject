const signIn = async () => {
    const userRegisterDetails = {
        userName: document.getElementById("userName").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
   
    };
    const GetUserRegisterDetailsPost = await fetch('api/Users/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userRegisterDetails)
    });
    const userRegisterPost = await GetUserRegisterDetailsPost.json();
    console.log('register', userRegisterPost);
};

const logIn = async () => {
    const userLoginDetails = {
        userName: document.getElementById("userNameLogin").value,
        password: document.getElementById("passwordLogin").value,
    };
    const GetUserLoginDetailsPost = await fetch('api/Users/logIn', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userLoginDetails)

    });
    const userLoginPost = await GetUserLoginDetailsPost.json();
    console.log('login user:', userLoginPost);
    localStorage.setItem("CurrentLoginUser", JSON.stringify(userLoginPost));
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
    const GetUserUpdateDetails = await fetch(`api/Users/${userid}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userUpdateDetails)
    });
    const userUpdate = await GetUserUpdateDetails.json();
    console.log('update user data:', userUpdate)

}

