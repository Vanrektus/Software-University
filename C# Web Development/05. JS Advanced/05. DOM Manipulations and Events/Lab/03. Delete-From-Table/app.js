function deleteByEmail() {
    let inputElement = document.querySelector('input').value;
    let emailsElements = document.querySelectorAll('tbody tr td:nth-child(2)');

    for (const currElement of emailsElements) {
        if (currElement.textContent == inputElement) {
            let emailToRemove = currElement.parentNode;
            emailToRemove.parentNode.removeChild(emailToRemove);

            document.querySelector('#result').textContent = "Deleted.";

            return;
        }

        document.querySelector('#result').textContent = "Not found.";
    }
}