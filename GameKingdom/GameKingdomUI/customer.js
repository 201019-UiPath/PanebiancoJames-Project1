function AddCustomer()
{
    let customer = {};
    customer.name = document.querySelector('#name').value;
    customer.password = document.querySelector('#password').value;
    customer.address = document.querySelector('#address').value;

    let xhr = new XMLHttpRequest();
    xhr.onreadystatechange = function() {
        if(this.readyState == 4 && this.response > 199 && this.respone < 300)
        {
            alert("New Customer Added");
            document.querySelector('#name').value = '';
            document.querySelector('#password').value = '';
            document.querySelector('#address').value = '';

        }
    };

    xhr.open("POST", 'https://localhost:44389/Customer/add', true)

    xhr.setRequestHeader('Content-Type', 'application/json');
    xhr.send(JSON.stringify(customer));
}

function GetAllCustomers()
{
    fetch('https://localhost:44389/Customer/get')
    .then(response => response.json())
    .then(result => {
        document.querySelectorAll('#customers tbody tr').forEach(element => element.remove());
        let table = document.querySelector('#customers tbody');
        for(let i = 0; i < result.length; ++i)
        {
            let row = table.insertRow(table.rows.length);
            let nmCell = row.insertCell(0);
            nmCell.innerHTML = result[i].name;

            let addCell = row.insertCell(1);
            addCell.innerHTML = result[i].address;

        }
    });
}