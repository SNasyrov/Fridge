const productsId = [];

var checkboxes = document.querySelectorAll('.checkbox');

var text = '<span> you selected : </span>';

for (var checkbox of checkboxes) {
    checkbox.addEventListener('click', function () {
        if (this.checked == true) {
            productsId.push(this.value);
            valueList.innerHTML = text + productsId;
        }
    })
    let xhr = new XMLHttpRequest();
    xhr.open("Post", "/RecipeList/Show/ProductToRecipeAdd");
    xhr.send(productsId);
}

