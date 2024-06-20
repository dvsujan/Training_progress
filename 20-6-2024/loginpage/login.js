const users = [
    { username: 'dvsujan', password: 'pass123' },
    { username: 'user', password: 'pass213' },
];

document.getElementById('login-form').addEventListener('submit', function(event) {
    event.preventDefault();

    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    const user = users.find(user => user.username === username && user.password === password);

    if (user) {
        document.getElementById('message').innerText = 'Login successful';
        document.getElementById('message').style.color = 'green';
    } else {
        document.getElementById('message').innerText = 'Login Failed';
        document.getElementById('message').style.color = 'red';
    }
});