const productsId = [];

var xhr = new XMLHttpRequest();

var checkboxes = document.querySelectorAll('.checkbox');

var text = '<span> you selected : </span>';

for (var checkbox of checkboxes) {
    checkbox.addEventListener('click', function () {
        if (this.checked == true) {
            productsId.push(this.value);
        }
    })
}

xhr.open("POST", '/submit', true);
xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
xhr.send(productsId);