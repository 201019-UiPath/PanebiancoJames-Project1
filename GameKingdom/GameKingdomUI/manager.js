function SignInManager()
{
    let manager = {};
    manager.name = document.querySelector('#name').value;
    manager.password = document.querySelector('#password').value;

    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function() {
        if(this.readyState == 4 && this.response > 199 && this.respone < 300)
        {
            alert("New Customer Added");
            document.querySelector('#name').value = '';
            document.querySelector('#password').value = '';
        }
    };

    xhr.open("GET", `https://localhost:44389/Manager/get/${name}/${password}`, true)

    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(manager));
}