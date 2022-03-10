export default function onClickHandler(e) {
    e.preventDefault();

    e.target.nextSibling.nextSibling.style.display = "block";
}