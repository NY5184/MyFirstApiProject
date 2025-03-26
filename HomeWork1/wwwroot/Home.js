const signIn = async () => {
    const userDetails = {
        userName: document.getElementById("userName").value,
        password: document.getElementById("password").value,
        firstName: document.getElementById("firstName").value,
        lastName: document.getElementById("lastName").value,
   
    };
    const GetUserDetailsPost = await fetch('api/Users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userDetails)
    });
    const userRegisterPost = await GetUserDetailsPost.json();
    console.log('POST Data:', userRegisterPost);
};