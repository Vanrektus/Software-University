function editElement(reference, match, replacer) {
    let content = reference.textContent;
    let matcher = new RegExp(match, "g");
    let edited = content.replace(matcher, replacer);
    reference.textContent = edited;
}
