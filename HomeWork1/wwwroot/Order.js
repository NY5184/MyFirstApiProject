//const sendOrder = async () => {
//    const orderSum = parseInt(document.getElementById("orderSum").value);
  

//    const currentUser = JSON.parse(localStorage.getItem("CurrentLoginUser"));
//    if (!currentUser || !currentUser.id) {
//        result.textContent = "User is not logged in.";
//        return;
//    }

//    const userId = currentUser.id;

//    if (isNaN(orderSum) || orderSum <= 0) {
//        result.textContent = "Please enter a valid order sum.";
//        return;
//    }
//    const order = {
//        orderSum: orderSum,
//        userId: userId,
//        orderDate: new Date().toISOString() // current date and time in ISO format
//    };

//    try {
//        const response = await fetch('/api/order', {
//            method: 'POST',
//            headers: {
//                'Content-Type': 'application/json'
//            },
//            body: JSON.stringify(order)
//        });

//        if (response.ok) {
//            const data = await response.json();
//            result.textContent = "Order placed successfully! Order ID: " + data.orderId;
//        } else {
//            const error = await response.text();
//            result.textContent = "Order failed: " + error;
//        }
//    } catch (err) {
//        result.textContent = "Error sending order: " + err.message;
//    }
//};
