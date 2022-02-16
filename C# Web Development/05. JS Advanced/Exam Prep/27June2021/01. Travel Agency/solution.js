window.addEventListener('load', solution);

function solution() {
    let submitButtonElement = document.querySelector('#submitBTN');
    let editButtonElement = document.querySelector('#editBTN');
    let continueButtonElement = document.querySelector('#continueBTN');

    let infoPreviewElement = document.querySelector('#infoPreview');

    submitButtonElement.addEventListener('click', submitButtonFunction);

    function submitButtonFunction(e) {
        e.preventDefault();

        let fullNameElement = document.querySelector('#fname');
        let emailElement = document.querySelector('#email');
        let phoneElement = document.querySelector('#phone');
        let addressElement = document.querySelector('#address');
        let codeElement = document.querySelector('#code');

        let fullNameCopy = fullNameElement.value;
        let emailCopy = emailElement.value;
        let phoneCopy = phoneElement.value;
        let addressCopy = addressElement.value;
        let codeCopy = codeElement.value;

        if (fullNameElement.value && emailElement.value) {
            // Create elements
            let liFullNameElement = document.createElement('li');
            liFullNameElement.textContent = `Full Name: ${fullNameElement.value}`;
            let liEmailElement = document.createElement('li');
            liEmailElement.textContent = `Email: ${emailElement.value}`;
            let liPhoneElement = document.createElement('li');
            liPhoneElement.textContent = `Phone Number: ${phoneElement.value}`;
            let liAddressElement = document.createElement('li');
            liAddressElement.textContent = `Address: ${addressElement.value}`;
            let liCodeElement = document.createElement('li');
            liCodeElement.textContent = `Postal Code: ${codeElement.value}`;

            infoPreviewElement.appendChild(liFullNameElement);
            infoPreviewElement.appendChild(liEmailElement);
            infoPreviewElement.appendChild(liPhoneElement);
            infoPreviewElement.appendChild(liAddressElement);
            infoPreviewElement.appendChild(liCodeElement);

            submitButtonElement.disabled = true;
            editButtonElement.disabled = false;
            continueButtonElement.disabled = false;

            editButtonElement.addEventListener('click', editButtonFunction);
            continueButtonElement.addEventListener('click', continueButtonFunction);

            fullNameElement.value = '';
            emailElement.value = '';
            phoneElement.value = '';
            addressElement.value = '';
            codeElement.value = '';

            function editButtonFunction(e) {
                e.preventDefault();

                fullNameElement.value = fullNameCopy;
                emailElement.value = emailCopy;
                phoneElement.value = phoneCopy;
                addressElement.value = addressCopy;
                codeElement.value = codeCopy;

                while (infoPreviewElement.firstChild) {
                    infoPreviewElement.removeChild(infoPreviewElement.firstChild);
                }

                submitButtonElement.disabled = false;
                editButtonElement.disabled = true;
                continueButtonElement.disabled = true;
            }

            function continueButtonFunction(e) {
                e.preventDefault();

                let mainDivElement = document.querySelector('#block');

                while (mainDivElement.firstChild) {
                    mainDivElement.removeChild(mainDivElement.firstChild);
                }

                let h3Element = document.createElement('h3');
                h3Element.textContent = `Thank you for your reservation!`;

                mainDivElement.appendChild(h3Element);
            }
        }
    }
}